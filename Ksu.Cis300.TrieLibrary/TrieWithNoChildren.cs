/* TrieWithNoChildren.cs
 * Author: Michael Crisp
 * Date: 25 March 2019
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// An implementation of a Trie using the ITrie 
    /// interface to deal with the instance of it having
    /// no children.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the Trie rooted here, contains the empty string.
        /// </summary>
        private bool _hasEmpty;

        /// <summary>
        /// Adds the string to the child, constructing a new one in this case.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if(s == "")
            {
                _hasEmpty = true;
                return this;
            }

            return new TrieWithOneChild(s, _hasEmpty);
        }

        
        /// <summary>
        /// Looks up the string in the trie.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmpty;
            }
            return false;
        }
    }
}
