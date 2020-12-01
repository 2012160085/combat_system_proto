using System.Collections;

namespace proto
{
    class Action
    {
        static Hashtable[] simplePool;
        static int simIdx;
        public static Hashtable SimpleAction(object obj){
            if(simplePool == null){
                simplePool = new Hashtable[20];
                for(int i =0; i < simplePool.Length; i++){
                    simplePool[i] = new Hashtable();
                }
            }
            simIdx = (simIdx + 1) % simplePool.Length;
            simplePool[simIdx]["value"] = obj;
            return simplePool[simIdx];
        }
        static Hashtable[] pool;
        static int idx;
        public static Hashtable GetAction(){
            if(pool == null){
                pool = new Hashtable[20];
                for(int i =0; i < pool.Length; i++){
                    pool[i] = new Hashtable();
                }
            }
            idx = (idx + 1) % pool.Length;
            pool[idx].Clear();
            return pool[idx];
        }
    }
}