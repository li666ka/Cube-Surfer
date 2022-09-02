using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay.RotationLogic
{
    public static class RotationsMap
    {
        private static Dictionary<Direction, Rule> _rules;

        static RotationsMap()
        {
            Rule forwardRule = new Rule(new [] { Direction.Left, Direction.Right }, new []{ -1, 1 });
            Rule backwardRule = new Rule(new [] { Direction.Left, Direction.Right }, new []{ 1, -1 });
            Rule leftRule = new Rule(new [] { Direction.Forward, Direction.Backward }, new []{ -1, 1 });
            Rule rightRule = new Rule(new [] { Direction.Left, Direction.Right }, new []{ 1, -1 });
            
            _rules = new Dictionary<Direction, Rule>();
            
            _rules.Add(Direction.Forward, forwardRule);
            _rules.Add(Direction.Backward, backwardRule);
            _rules.Add(Direction.Left, leftRule);
            _rules.Add(Direction.Right, rightRule);
        }
        
        public static int GetValue(Direction direction, Direction ruleDirection)
        {
            if (!IsDirectionAllowed(direction, ruleDirection))
            {
                throw new Exception("Forbidden direction");
            }
            
            return _rules[direction].ValuesMap[ruleDirection];
        }
        
        private static bool IsDirectionAllowed(Direction direction, Direction ruleDirection)
        {
            return _rules[direction].AllowedDirections.Contains(ruleDirection);
        }

        private class Rule
        {
            public Rule(Direction[] allowedDirections, int[] values)
            {
                AllowedDirections = allowedDirections;
                ValuesMap = new Dictionary<Direction, int>();

                for (int i = 0; i < AllowedDirections.Length; i++)
                {
                    ValuesMap.Add(AllowedDirections[i], values[i]);
                }
            }
            
            public Direction[] AllowedDirections { get; private set; }
            public Dictionary<Direction, int> ValuesMap { get; private set; }
        }
    }
}