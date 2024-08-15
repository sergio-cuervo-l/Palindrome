namespace PalabrasPalindromes
{
    public class Program
    {

        public bool esPalindrome(string palabra)
        {
            char[] arrayPalabra = palabra.ToCharArray();
            Array.Reverse(arrayPalabra);
            string reves = new string(arrayPalabra);
            return reves == palabra;
        }

        public string esPalindromeQuitandoLetras(string palabra)
        {
            char[] arrayPalabra = palabra.ToCharArray();

            //Buscar si la palabra es palindrome quitando una letra
            for (int i = 0; i < arrayPalabra.Length; i++)
            {
                char[] nuevoArray = arrayPalabra.Where(x => x != arrayPalabra[i]).ToArray();
                if (esPalindrome(new string(nuevoArray)))
                {
                    return $"La palabra es palindrome quitando la letra '{arrayPalabra[i]}' en la posición {i + 1}";
                }
            }

            //Buscar si la palabra es palindrome quitando dos letras
            for (int i = 0; i < arrayPalabra.Length - 1; i++)
            {
                char[] nuevoArray = arrayPalabra.Where(x => x != arrayPalabra[i]).ToArray();
                for (int j = i + 1; j < arrayPalabra.Length; j++)
                {
                    char[] nuevoArray2 = nuevoArray.Where(y => y != arrayPalabra[j]).ToArray();
                    if (esPalindrome(new string(nuevoArray2)))
                    {
                        return $"La palabra es palindrome quintado las letras '{arrayPalabra[i]}' y '{arrayPalabra[j]}' en las posiciones {i + 1} y {j + 1}";
                    }
                }
            }

            return "La palabra no es palindrome";
        }

        public string verificarPalindromo(string palabra)
        {
            if (esPalindrome(palabra.ToLower()))
                return "Es palindrome";
            else
                return esPalindromeQuitandoLetras(palabra.ToLower());
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.verificarPalindromo("Royior"));
        }
    }
}
