

namespace proto
{
    public class Callbacks
    {
        public static Callbacks instance;
        public Name name = new Name("");
        public delegate void del();
        public del printName;

    }
}
