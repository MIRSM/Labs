namespace PIASBuilder
{
    class Builder : IBuilder
    {
        private RoadMap _product = new RoadMap();

        public Builder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new RoadMap();
        }

        public void BuildWestStreets()
        {
            this._product.Add("Западные улицы");
        }

        public void BuildNorthStreets()
        {
            this._product.Add("Северные улицы");
        }

        public void BuildSouthStreets()
        {
            this._product.Add("Южные улицы");
        }

        public void BuildEastStreets()
        {
            this._product.Add("Восточные улицы");
        }

        public RoadMap GetProduct()
        {
            RoadMap result = this._product;
            this.Reset();
            return result;
        }
    }
}
