using Elibrium.Domain;



namespace Elibrium.BO
{
    public class EmailTemplateBO : BaseBO
    {
        public string _body { get; set; }
        public string _header { get; set; }
        public string _type { get; set; }

        public string Body{
            get{
            return _body;
            }
        }
        public string Header
        {
            get
            {
                return _header;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
        }


        public EmailTemplateBO (EmailTemplate et){
            _body = et.Body;
            _header = et.Header;
            _type = et.Type;
        }

        private EmailTemplate parseDomain()
        {
            return new EmailTemplate()
            {
                Body = _body,
                Header = _header,
                Type = _type
            };
        }
    }
}
