using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupMeHodor
{
    public class Hodor
    {
        private readonly Random mRandom;

        private string[] mHodors = new string[]
        {
            "Hodor",
            "Hodor!",
            "HODOR",
            "Hodor?",
            "Hodooorrr",
            "HODOR!!!",
            "HOODOOORRRR",
            "*HODOR*"
        };

        public Hodor(Random random)
        {
            if (random == null)
                throw new ArgumentNullException("random");

            this.mRandom = random;
        }

        public string GetRandom()
        {
            if (this.mHodors == null || this.mHodors.Length == 0)
                return null;

            int index = this.mRandom.Next(0, this.mHodors.Length);

            return this.mHodors[index];
        }
    }
}
