using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starcraft
{
	// StarCode 1.4 C# Version
	public class Starcode
	{
		public String m_alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!$%/()=?,.-;:_^#+* @{[]}|~`";

		public Starcode()
		{
		}

		/* Sets the alphabet of characters that can be properly encrypted by Starcode */
		public void SetAlphabet(String alphabet)
		{
			m_alphabet = alphabet;
		}

		/* Returns the character representation of an ordinal based on the current alphabet */
		private string chr(int i)
		{
			return m_alphabet.Substring(i, 1);
		}

		/* Returns an integer representation of a character in the current alphabet */
		private int ord(string i)
		{
			return m_alphabet.IndexOf(i);
		}


		private string shiftForward(string s, string k)
		{
			return chr((ord(s) + ord(k)) % m_alphabet.Length);
		}

		private string shiftBackward(string s, string k)
		{
			int c = ord(s) - ord(k);
			if (c < 0)
			{
				return chr((c + m_alphabet.Length) % m_alphabet.Length);
			}
			else
			{
				return chr(c % m_alphabet.Length);
			}
		}

		/* Encrypt string s with string key. returns encrypted string */
		public string Encrypt(string s, string key)
		{
			int ls = s.Length;
			int lk = key.Length;
			string ret = "";
			for (int i = 0; i < ls; ++i)
			{
				ret += shiftForward(s.Substring(i, 1), key.Substring(i % lk, 1));
			}
			return ret;
		}

		/* Decrypts the string s with the string "key" */
		public string Decrypt(string s, string key)
		{
			int ls = s.Length;
			int lk = key.Length;
			string ret = "";
			for (int i = 0; i < ls; ++i)
			{
				ret += shiftBackward(s.Substring(i, 1), key.Substring(i % lk, 1));
			}
			return ret;
		}		

		public string Hash(string toHash, int securityLevel)
		{
			// TODO Implement
			return null;
		}

		public string RemoveHash(string lp_string, int lp_securityLevel)
		{
			// TODO Implement
			return null;
		}

		public string CompressString(string toCompress)
		{
			// TODO Implement
			return null;
		}

		public string DecompressString(string toDecompress)
		{
			// TODO Implement
			return null;
		}

		/* Extracts an encryption key from a source string and the resulting encrypted string.
		 * if the method fails, then null string is returned. */
		public string DecryptKey(string original, string encrypted)
		{
			String s = "";
			for (int i = 0; i < original.Length; ++i)
			{
				int indexKey = i % encrypted.Length;

				int ordStart = ord(original.Substring(i, 1));
				int ordResult = ord(encrypted.Substring(indexKey, 1));

				for (int x = 0; x < m_alphabet.Length; ++x)
				{
					if (Encrypt(chr(ordStart), m_alphabet.Substring(x, 1)) == chr(ordResult))
					{
						s += m_alphabet.Substring(x, 1);
					}
				}
			}

			if (Encrypt(original, s).Equals(encrypted))
				return s;

			return "";
		}
	}
}