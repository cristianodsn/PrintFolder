
namespace rascunho.Entities
{
    public class Status
    {
        public string Way { get; private set; }
        public int Type { get; private set; }

        public Status() { }
        
        public Status(string way, int type)
        {
            Way = way;
            Type = type;
        }

        public void TurnWay (string way)
        {
            Way = way;
        }
        public void TurnType(int type)
        {
            Type = type;
        }       
    }
}
