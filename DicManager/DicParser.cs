using ConsoleApp1.Chinese.WordInfo;
using Fal.Chinese.Helpers;
using Fal.DataStructure.Tree;
using Fal.Nlp;
using Fal.Nlp.Chinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Chinese.DicManager
{
    public class DicParser
    {



        private string _str;
        private int _current;
        private char _token;
        private char _next => _str[++_current];
        private bool hasNext => _current + 1 < _str.Length - 1;
        private DicParserState _state;
        private string _temp;
        private _WordInnfo _w;
        private WordType _type;
        private bool _istypestarted;
        private bool _ispinyinstarted;
        private Search_Tree<_WordInnfo> _dic;
        private bool _reverseName;
        public void Parse(string str, Search_Tree<_WordInnfo> dic, bool reverseName = false)
        {
            _reverseName = reverseName;
            _str = str;
            _dic = dic;
            _current = -1;
            while (hasNext)
            {
                _token = _next;
                switch (_state)
                {
                    case DicParserState.Default:
                        _default();
                        break;
                    case DicParserState.Name:
                        name();
                        break;
                    case DicParserState.PreType:
                        pretype();
                        break;
                    case DicParserState.Type:
                        type();
                        break;
                    case DicParserState.Frequency:
                        frequency();
                        break;
                    case DicParserState.Pinyin:
                        pinyin();
                        break;
                    default:
                        _default();
                        break;
                }
            }

        }

        private void _default()
        {
            switch (_token)
            {
                case '(':
                    _state = DicParserState.Name;
                    break;
                default:
                    break;
            }
        }
        private void name()
        {
            switch (_token)
            {
                case ')':
                    _w = new _WordInnfo();
                    if (_reverseName)
                        _w.Name = StringHelper.Reverse(_temp);
                    else
                        _w.Name = _temp;
                    _temp = string.Empty;
                    _state = DicParserState.PreType;
                    break;
                default:
                    _temp += _token;
                    break;
            }
        }

        private void pretype()
        {
            switch (_token)
            {
                case '(':
                    _state = DicParserState.Type;
                    break;
                default:
                    break;
            }
        }
        private void type()
        {
            switch (_token)
            {
                case ')':
                    _state = DicParserState.Pinyin;
                    break;
                case '[':
                    _istypestarted = true;
                    break;
                case ',':
                    if (!_istypestarted)
                        error();
                    else
                    {
                        _type = _temp.GetWordTypeFromString();
                        _temp = string.Empty;
                        _istypestarted = false;
                        _state = DicParserState.Frequency;
                    }
                    break;
                default:
                    if (_istypestarted)
                        _temp += _token;
                    break;
            }
        }
        private void frequency()
        {
            switch (_token)
            {
                case ']':
                    _w.Add(_type, int.Parse(_temp));
                    _temp = string.Empty;
                    _state = DicParserState.Type;
                    break;
                default:
                    _temp += _token;
                    break;
            }
        }

        private void pinyin()
        {
            switch (_token)
            {
                case '(':
                    _ispinyinstarted = true;
                    break;
                case ')':
                    if (!_ispinyinstarted)
                        error();
                    else
                    {
                        _ispinyinstarted = false;
                        _w.PinYin = _temp;
                        _temp = string.Empty;
                        _dic.Add_Node(_w);
                        _state = DicParserState.Default;
                    }
                    break;
                default:
                    if (_ispinyinstarted)
                        _temp += _token;
                    break;
            }
        }

        private void error()
        {
            throw new Exception($"{_current}附近书写错误！");
        }
    }
}
