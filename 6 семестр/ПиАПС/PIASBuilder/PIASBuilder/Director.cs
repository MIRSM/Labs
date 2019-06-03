namespace PIASBuilder
{
    class Director
    {
        private IBuilder _builder;
        public IBuilder Builder
        {
            set { _builder = value; }
        }
        public void buildMinimalMap()
        {
            _builder.BuildNorthStreets();
        }
        public void buildFullMap()
        {
            _builder.BuildNorthStreets();
            _builder.BuildSouthStreets();
            _builder.BuildWestStreets();
            _builder.BuildEastStreets();
        }
    }
}
