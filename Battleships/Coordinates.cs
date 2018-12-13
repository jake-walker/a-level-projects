using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            Char row = (Char)(97 + (Row - 1));
            return $"{row.ToString().ToUpper()}{Column}";
        }

        public string ToDigits()
        {
            return $"{Row},{Column}";
        }

        public string ToSingleChar()
        {   
            if (Column == 0 && Row == 0)
            {
                return "";
            } else if (Column == 0)
            {
                Char row = (Char)(97 + (Row - 1));
                return row.ToString().ToUpper();
            } else if (Row == 0)
            {
                return Column.ToString();
            } else
            {
                return ToString();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates other)
        {
            return other != null &&
                   Row == other.Row &&
                   Column == other.Column;
        }

        public override int GetHashCode()
        {
            var hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }

        // Change what data is hashed so that when we compare it doesn't also use functions
        /*public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Column.GetHashCode();
        }*/
    }
}
