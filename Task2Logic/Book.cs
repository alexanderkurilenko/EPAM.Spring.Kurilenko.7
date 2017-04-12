using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class Book:IComparable<Book>,IEquatable<Book>
    {
        #region Props
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Iquatable method implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Book other)
        {
            return (Title == other.Title) && (Author == other.Author) && (Length == other.Length);
        }

        /// <summary>
        /// overrding method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() == typeof(Book))
            {
                Equals((Book)obj);
            }

            return false;
        }

        public override string ToString()
        {
            return Title + " " + Author + " " + Length;
        }

        /// <summary>
        /// CompareTo interface implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Book other)
        {
            if (Length>other.Length)
            {
                return 1;
            }
            else if(Length<other.Length)
            {
                return -1;
            }
            return 0;
        }
        #endregion

    }
}
