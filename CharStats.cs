using System;
using System.Collections;
namespace proto
{
    class CharStats
    {
        public CharStats(int hp, int str, int dex, int knw, int luk){
            Hp = hp;
            Str = str;
            Dex = dex;
            Knw = knw;
            Luk = luk;
        }
        int hp;
        int str;
        int dex;
        int knw;
        int luk;

        public int Hp { get => hp; set => hp = value; }
        public int Str { get => str; set => str = value; }
        public int Dex { get => dex; set => dex = value; }
        public int Knw { get => knw; set => knw = value; }
        public int Luk { get => luk; set => luk = value; }
        //-------------------------------

       
        public override string ToString()
        {
            return "HP:" + hp + "/STR:" + str + "/DEX:" + dex + "/INT:" + knw + "/LUK:" + luk ;
        }
    }
}
