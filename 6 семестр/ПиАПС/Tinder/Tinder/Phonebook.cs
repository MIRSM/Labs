namespace Tinder
{
    class Phonebook : AbstractHandler
    {
        public override object Handle(object request)
        {
            switch (request as string)
            {
                case "Пушкин Александр Сергеевич":
                case "Достоевский Федр Михайлович":
                    return $"нашли в телефонной книге";
                default:
                    return base.Handle(request);
            }
        }
    }
}
