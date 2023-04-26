
using expression_tree;
using proyecto.REGULAR_EXPRESION;




//proyecto.readFile.Read();


//Acá voy a poner mi lista de pruebas 

List<string> tokens = new List<string>();
tokens.Add("(");
tokens.Add("(");
tokens.Add("a");
tokens.Add(".");
tokens.Add("(");
tokens.Add("a");
tokens.Add(".");
tokens.Add("a");
tokens.Add(".");
tokens.Add("b");
tokens.Add(".");
tokens.Add("b");
tokens.Add(")");
tokens.Add("+");
tokens.Add(")");
tokens.Add("|");
tokens.Add("(");
tokens.Add("b");
tokens.Add(".");
tokens.Add("(");
tokens.Add("a");
tokens.Add(".");
tokens.Add("a");
tokens.Add(".");
tokens.Add("b");
tokens.Add(".");
tokens.Add("b");
tokens.Add(")");
tokens.Add("+");
tokens.Add(")");
tokens.Add(")");
tokens.Add(".");

tokens.Add("#");

//convert_to_RET.generateRegularExpressionTree(tokens);

GenerateString.printList();

proyecto.ReadFile.read();

Console.ReadLine();

