using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAndTea
{
    class Products
    {
        private string _category;
        private string _name;
        private string _description;
        private decimal _price;

        public string Category
        {
            get { return this._category; }
            set { this._category = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public decimal Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public Products(string category, string name, string description, decimal price)
        {
            this._category = category;
            this._name = name;
            this._description = description;
            this._price = price;
        }

        public Products()
        {
            this._category = "";
            this._name = "";
            this._description = "";
            this._price = 0;
        }

        public override string ToString()
        {

            return $"{this._category} {this._name} {this._description} ${this._price}";

        }

    }
}
