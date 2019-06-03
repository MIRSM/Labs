namespace Tinder
{
    //Прохожий (спросить прохожего)
    class Passersby : AbstractHandler
    {
        public override object Handle(object request)
        {
            switch (request as string)
            {
                case "Иванов Иван Иванович":
                case "Петров Петр Петрович":
                    return $"нашли прохожие";
                default:
                    return base.Handle(request);
            }
        }
    }
}
