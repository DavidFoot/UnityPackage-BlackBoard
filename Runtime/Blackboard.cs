using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackBoardRuntime
{
    [Serializable]
    public readonly struct BlackboardKey : IEquatable<BlackboardKey>
    {
        readonly string _name;
        readonly int _hashedKey;

        public BlackboardKey(string name)
        {
            this._name = name;
            _hashedKey = name.GetHashCode();
        }
        public bool Equals(BlackboardKey other) => _hashedKey == other._hashedKey;
        public override bool Equals(object obj) => obj is BlackboardKey other && Equals(other);
        public override int GetHashCode() => _hashedKey;
        public override string ToString() => _name;
        public static bool operator ==(BlackboardKey left, BlackboardKey right) => left._hashedKey == right._hashedKey;
        public static bool operator !=(BlackboardKey left, BlackboardKey right) => !(left == right);


    }

    [Serializable]
    class Blackboard
    {
        Dictionary<string, BlackboardKey> _keyRegistry = new();
        Dictionary<string, object> entries = new();
    }

}
