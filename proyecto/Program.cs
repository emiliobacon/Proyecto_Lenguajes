
using expression_tree;
using proyecto.REGULAR_EXPRESION;

proyecto.ReadFile.read();

//proyecto.readFile.Read();

GenerateString.printList();
//Acá voy a poner mi lista de pruebas 

List<string> tokens = new List<string>();
tokens.Add("(");
tokens.Add("(");
tokens.Add("0");
tokens.Add("|");
tokens.Add("1");
tokens.Add("*");
tokens.Add(")");
tokens.Add("+");
tokens.Add(".");
tokens.Add("0");
tokens.Add("?");
tokens.Add("|");
tokens.Add("1");
tokens.Add("+");
tokens.Add(")");
tokens.Add(".");
tokens.Add("#");


convert_to_RET.generateRegularExpressionTree(tokens);

Console.ReadLine();

