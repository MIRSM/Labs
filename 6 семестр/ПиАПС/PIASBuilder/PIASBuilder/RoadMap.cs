using System;
using System.Collections.Generic;

namespace PIASBuilder
{
    class RoadMap
    {
        private List<object> _streets = new List<object>();

        public void Add(string streets)
        {
            this._streets.Add(streets);
        }

        public string ListFloors()
        {
            string str = String.Empty;
            for(int i = 0; i < this._streets.Count ; i++)
            {
                str += this._streets[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Порядок построения карты автодорог: "+str+"\n";
        }
    }
}
