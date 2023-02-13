using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DAL
{
    public static class EFExtensions
    {
        /// <summary>
        /// Generate a Datatable from a DbSet
        /// </summary>
        /// <typeparam name="T">Generic Type for Entity</typeparam>
        /// <see cref="https://stackoverflow.com/questions/27738238/convert-dbcontext-to-datatable-in-code-first-entity-framework"/>
        public static DataTable ToDataTable<T>(this IQueryable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
