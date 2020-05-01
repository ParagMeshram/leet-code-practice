namespace FriendsOfAppropriateAges
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class SolutionBruteForce
    {
        public int NumFriendRequests(int[] ages)
        {
            var count = 0;

            for (int i = 0; i < ages.Length; i++)
            {
                for (int j = 0; j < ages.Length; j++)
                {
                    if (i != j && CanAddAsFriend(ages[i], ages[j]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool CanAddAsFriend(int a, int b)
        {
            return !((b > a)
                     || (b > 100 && a < 100)
                     || (b <= (0.5 * a + 7)));
        }
    }

    public class SolutionLeetCode
    {
        public int NumFriendRequests(int[] ages)
        {
            const int MAX_AGE = 120;

            var ans = 0;

            var count = new int[MAX_AGE + 1]; // index = age, count[index] = person count of that age

            foreach (var age in ages) count[age]++;

            for (int a = 0; a <= MAX_AGE; a++)
            {
                for (int b = 0; b <= MAX_AGE; b++)
                {
                    if (!CanAddAsFriend(a, b)) continue;

                    ans += count[a] * count[b];

                    if (a == b)
                        ans -= count[a];
                }
            }

            return ans;
        }

        private bool CanAddAsFriend(int a, int b)
        {
            return !(
                (b > a)
                || (b > 100 && a < 100)
                || (b <= (0.5 * a + 7))
            );
        }
    }
}