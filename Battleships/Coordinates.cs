using System;

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

        public static Coordinates Parse(string input)
        {
            input = input.ToLower();

            if (input.Length != 2)
            {
                return null;
            }

            if (!int.TryParse(input[1].ToString(), out var colnum))
            {
                return null;
            }

            var row = input[0];
            var rownum = ((row + 1) - 97);

            if (rownum <= 0 || colnum <= 0)
            {
                return null;
            } 

            return new Coordinates(rownum, colnum);
        }

        public override string ToString()
        {
            var row = (char)(97 + (Row - 1));
            return $"{row.ToString().ToUpper()}{Column}";
        }

        public string ToDigits()
        {
            return $"{Row},{Column}";
        }

        public string ToSingleChar()
        {
            switch (Column)
            {
                case 0 when Row == 0:
                    return "";
                case 0:
                {
                    var row = (char)(97 + (Row - 1));
                    return row.ToString().ToUpper();
                }
                default:
                {
                    return Row == 0 ? Column.ToString() : ToString();
                }
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
    }
}
