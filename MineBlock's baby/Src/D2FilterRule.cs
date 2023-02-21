using NetLimiter.Service;
using NLMMB.Src;
using System.Windows.Forms;

namespace NLMMB
{
    internal class D2FilterRule
    {
        public string Name;
        private readonly RuleDir _ruleDir;
        private readonly uint _bps;
        private readonly ushort _portStart;
        private readonly ushort _portEnd;
        private readonly NLClient _client;
        private readonly Filter _filt;
        private readonly Rule _rule;
        private readonly Filter _filtModel;
        private readonly Rule _ruleModel;

        public D2FilterRule(NLClient client, string appPath, string name, RuleDir ruleDir, uint bps, ushort portStart = 0, ushort portEnd = 0)
        {
            Name = name;
            _ruleDir = ruleDir;
            _bps = bps;
            _portStart = portStart;
            _portEnd = portEnd;
            _client = client;

            _filtModel = new Filter(Name);
            _filtModel.Functions.Add(new FFAppIdEqual(new AppId(appPath)));
            _filtModel.Functions.Add(new FFRemotePortInRange(new PortRangeFilterValue(_portStart, _portEnd)));
             
            _ruleModel = new LimitRule(_ruleDir, _bps);
            _filt = _client.Filters.Find(x => x.Name == Name);

            if (!Exists())
            {
                _filt = _client.AddFilter(_filtModel);
                _rule = _client.AddRule(_filtModel.Id, _ruleModel);
            }
            else
            {
                _client.RemoveFilter(_filt);
                _filt = _client.AddFilter(_filtModel);
                _rule = _client.AddRule(_filtModel.Id, _ruleModel);
            }

            _rule.IsEnabled = false;
            _client.UpdateRule(_rule);
        }

        public bool Exists()
        {
            return _filt != null;
        }
    }
}