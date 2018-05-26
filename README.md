# Chinese-Lexicier
Segmente Chinese Sentence  To Words
字典的加载速度较慢，大概需要7,8秒
内存使用量大概为70-80兆
如果想要提高，应重新设计字符搜索树的添加节点的模块
消岐效果还不错的，分词速度大概20万字符每秒。
如果需要提高分词速度，削减_WordInfo不必要属性
并取消copy的方式，修改为传递引用
如果想要提高速度
## Usage
### eg
``` c#
 Lexicer lex = new Lexicer(new LexConfig("dic9.txt", "", "singleword2.txt", true, false));
var b=lex.Work("已经结婚的和尚未结婚的人，都要努力。");
/*********************************
 *返回一个passage对象赋值给b
  ***************************************/
```
