using System;

class Trie
{

   TrieNode root;
   public Trie()
   {
       root = new TrieNode();
   }
   public void Insert(string word)
   {
       var n = word.Length;
       TrieNode curNode = root;
       for (int i = 0; i < n; i++)
       {
           var index = word[i] - 'a';
           if (curNode.nodes[index] == null)
           {
               curNode.nodes[index] = new TrieNode();
           }
           curNode = curNode.nodes[index];


       }
       curNode.isWord = true;
   }
    public bool checkIfAllPrefixExists(String word)
       {
           var n = word.Length;
           bool isword = true;
           TrieNode curNode = root;

           for (int i = 0; i < word.Length && isword; i++)
           {
               var index = word[i] - 'a';
               if (curNode.nodes[index] != null)
               {
                   curNode = curNode.nodes[index];
                   isword = isword & curNode.isWord;
               }

               else
               {
                   return false;
               }
           }
           return isword;
       }
   public bool Search(string word)
   {
       var n = word.Length;
       TrieNode curNode = root;
       for (int i = 0; i < n; i++)
       {
           var index = word[i] - 'a';
           if (curNode.nodes[index] == null)
           {
               return false;
           }
           curNode = curNode.nodes[index];
       }
       return curNode.isWord;
   }
     
   public bool StartsWith(string prefix)
   {
       var n = prefix.Length;
       TrieNode curNode = root;
       for (int i = 0; i < n; i++)
       {
           var index = prefix[i] - 'a';
           if (curNode.nodes[index] == null)
           {
               return false;
           }
           curNode = curNode.nodes[index];
       }
       return true;
   }
}

class TrieNode
{
   public TrieNode[] nodes;
   public bool isWord;


   public TrieNode()
   {
       nodes = new TrieNode[26];
       isWord = false;
   }
}


class main
{
   public static void Main(String[] args)
   {


       Trie trie = new Trie();

       string[] value = { "the", "a", "there", "answer",
                       "any", "by", "bye", "their"};

       String[] output = { "Not present in trie", "Present in trie" };

       int i;
       for (i = 0; i < value.Length; i++)
           trie.Insert(value[i]);

            int a = value.Length;

           string b = completeString(a, value);

           Console.WriteLine(b);



       if (trie.Search("the") == true)
           Console.WriteLine("the --- " + output[1]);
       else Console.WriteLine("the --- " + output[0]);

       if (trie.Search("these") == true)
           Console.WriteLine("these --- " + output[1]);
       else Console.WriteLine("these --- " + output[0]);

       if (trie.Search("their") == true)
           Console.WriteLine("their --- " + output[1]);
       else Console.WriteLine("their --- " + output[0]);

       if (trie.StartsWith("thaw") == true)
           Console.WriteLine("thaw --- " + output[1]);
       else Console.WriteLine("thaw --- " + output[0]);
   }

     public static String completeString(int n, String[] a)
       {
           Trie obj = new Trie();
           for (int i = 0; i < n; i++)
           {
               obj.Insert(a[i]);
           }
           String longest = "";
           for (int i = 0; i < n; i++)
           {
               if (obj.checkIfAllPrefixExists(a[i]))
               {
                   if (a[i].Length > longest.Length)
                   {
                       longest = a[i];
                   }

                   else if (a[i].Length == longest.Length && a[i].CompareTo(longest) < 0)
                   {
                       longest = a[i];
                   }
               }
           }
           if (longest == "") return "None";
           return longest;

       }

    public class Solution
    {
        public static void Main(String[] args)
        {

            Trie trie = new Trie();

            int b = trie.countDistinctSubStrings("abab");

            Console.WriteLine("THE VALUE OF DISTICT ELLEMTNS:"+b);

        }


        class Trie
        {

            TrieNode root;
            public Trie()
            {
                root = new TrieNode();
            }
            public int countDistinctSubStrings(string word)
            {
                var n = word.Length;
                int a = 0;
                for (int i = 0; i < n; i++)
                {
                    TrieNode curNode = root;
                    for (int j = i; j < n; j++)
                    {
                        var index = word[j] - 'a';
                        if (curNode.nodes[index] == null)
                        {
                            curNode.nodes[index] = new TrieNode();
                            a++;
                        }
                        curNode = curNode.nodes[index];


                    }
                }

                return 1 + a;

            }


        }
        class TrieNode
        {
            public TrieNode[] nodes;



            public TrieNode()
            {
                nodes = new TrieNode[26];

            }
        }
    }
}


