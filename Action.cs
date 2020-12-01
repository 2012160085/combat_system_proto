using System.Collections;

namespace proto
{
    class Action
    {
        static Hashtable[] pool;
        static int idx;
        public static Hashtable SimpleAction(object obj){
            if(pool == null){
                pool = new Hashtable[20];
                for(int i =0; i < pool.Length; i++){
                    pool[i] = new Hashtable();
                }
            }
            idx = (idx + 1) % pool.Length;
            pool[idx]["value"] = obj;
            return pool[idx];
        }
    }
}