using System;

namespace ClubElo.API.Attributes
{
    internal class ColumnNameAttribute : Attribute
    {
        private readonly string names;

        public ColumnNameAttribute(string names)
        {
            this.names = names;
        }

        public string Names => names;
    }
}
