# Chinese-Lexicier
Segmente Chinese Sentence  To Words
## Usage
### eg
``` c#
 Lexicer lex = new Lexicer(new LexConfig("dic9.txt", "", "singleword2.txt", true, false));
var b=lex.Work("已经结婚的和尚未结婚的人，都要努力。");
```
