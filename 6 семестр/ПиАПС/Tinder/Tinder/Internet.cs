namespace Tinder
{
    class Internet : AbstractHandler
    {
        public override object Handle(object request)
        {
            switch (request as string)
            {
                case "Гарри Поттер":
                case "Гендальф Белый":
                    return $"нашли через интернет";
                default:
                    return base.Handle(request);
            }
        }
    }
}
