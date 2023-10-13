﻿using System;
using System.Collections.Immutable;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guessNumbers)
        {
            int bullCount = 0;
            int cowCount = 0;
            int guessNumberIndex = 0;
            guessNumbers.ToImmutableList().ForEach(guessNumber =>
                {
                    int matchedSceretNumberIdex = secret.IndexOf(guessNumber);
                    if (matchedSceretNumberIdex >= 0)
                    {
                        if (matchedSceretNumberIdex == guessNumberIndex)
                        {
                            bullCount++;
                        }
                        else
                        {
                            cowCount++;
                        }
                    }

                    guessNumberIndex++;
                });
            return bullCount + "A" + cowCount + "B";
        }
    }
}