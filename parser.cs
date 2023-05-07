
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_MINUS         =  3, // '-'
        SYMBOL_MINUSMINUS    =  4, // '--'
        SYMBOL_EXCLAMEQ      =  5, // '!='
        SYMBOL_PERCENT       =  6, // '%'
        SYMBOL_LPAREN        =  7, // '('
        SYMBOL_RPAREN        =  8, // ')'
        SYMBOL_TIMES         =  9, // '*'
        SYMBOL_TIMESTIMES    = 10, // '**'
        SYMBOL_DIV           = 11, // '/'
        SYMBOL_COLON         = 12, // ':'
        SYMBOL_SEMI          = 13, // ';'
        SYMBOL_LBRACE        = 14, // '{'
        SYMBOL_RBRACE        = 15, // '}'
        SYMBOL_PLUS          = 16, // '+'
        SYMBOL_PLUSPLUS      = 17, // '++'
        SYMBOL_LT            = 18, // '<'
        SYMBOL_EQ            = 19, // '='
        SYMBOL_EQEQ          = 20, // '=='
        SYMBOL_GT            = 21, // '>'
        SYMBOL_CASE          = 22, // case
        SYMBOL_DEFAULT       = 23, // default
        SYMBOL_DIGIT         = 24, // Digit
        SYMBOL_DIGITAL       = 25, // Digital
        SYMBOL_DOUBLE        = 26, // double
        SYMBOL_ELSE          = 27, // else
        SYMBOL_END           = 28, // End
        SYMBOL_FLOAT         = 29, // float
        SYMBOL_FOR           = 30, // For
        SYMBOL_ID            = 31, // Id
        SYMBOL_IF            = 32, // if
        SYMBOL_INT           = 33, // int
        SYMBOL_START         = 34, // Start
        SYMBOL_STRING        = 35, // string
        SYMBOL_SWITCH        = 36, // switch
        SYMBOL_ASSIGN        = 37, // <assign>
        SYMBOL_CASEBLOCK     = 38, // <Case Block>
        SYMBOL_CASECLAUSE    = 39, // <Case Clause>
        SYMBOL_CASECLAUSES   = 40, // <Case Clauses>
        SYMBOL_CONCEPT       = 41, // <concept>
        SYMBOL_COND          = 42, // <cond>
        SYMBOL_DATA          = 43, // <data>
        SYMBOL_DEFAULTCLAUSE = 44, // <Default Clause>
        SYMBOL_DIGIT2        = 45, // <digit>
        SYMBOL_EXP           = 46, // <exp>
        SYMBOL_EXPR          = 47, // <expr>
        SYMBOL_FACTOR        = 48, // <factor>
        SYMBOL_FOR_STMT      = 49, // <for_stmt>
        SYMBOL_ID2           = 50, // <id>
        SYMBOL_IF_STMT       = 51, // <if_stmt>
        SYMBOL_OP            = 52, // <op>
        SYMBOL_PROGRAM       = 53, // <program>
        SYMBOL_STEP          = 54, // <step>
        SYMBOL_STMT_LIST     = 55, // <stmt_list>
        SYMBOL_SWITCH_STMT   = 56, // <Switch_Stmt>
        SYMBOL_TERM          = 57  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                  =  0, // <program> ::= Start <stmt_list> End
        RULE_STMT_LIST                                          =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                                         =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                            =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                           =  4, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                           =  5, // <concept> ::= <for_stmt>
        RULE_ASSIGN_EQ_SEMI                                     =  6, // <assign> ::= <id> '=' <expr> ';'
        RULE_ID_ID                                              =  7, // <id> ::= Id
        RULE_EXPR_PLUS                                          =  8, // <expr> ::= <expr> '+' <expr>
        RULE_EXPR_MINUS                                         =  9, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                               = 10, // <expr> ::= <term>
        RULE_TERM_TIMES                                         = 11, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                           = 12, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                       = 13, // <term> ::= <term> '%' <factor>
        RULE_TERM                                               = 14, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                  = 15, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                             = 16, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                  = 17, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                = 18, // <exp> ::= <id>
        RULE_EXP2                                               = 19, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                        = 20, // <digit> ::= Digit
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_END                 = 21, // <if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_END_ELSE            = 22, // <if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End else <stmt_list>
        RULE_COND                                               = 23, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                              = 24, // <op> ::= '<'
        RULE_OP_GT                                              = 25, // <op> ::= '>'
        RULE_OP_EQEQ                                            = 26, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                        = 27, // <op> ::= '!='
        RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE = 28, // <for_stmt> ::= For '(' <data> <assign> ';' <cond> ';' <step> ')' '{' <stmt_list> '}'
        RULE_DATA_INT                                           = 29, // <data> ::= int
        RULE_DATA_FLOAT                                         = 30, // <data> ::= float
        RULE_DATA_DOUBLE                                        = 31, // <data> ::= double
        RULE_DATA_STRING                                        = 32, // <data> ::= string
        RULE_STEP_MINUSMINUS                                    = 33, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                   = 34, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                      = 35, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                     = 36, // <step> ::= <id> '++'
        RULE_STEP                                               = 37, // <step> ::= <assign>
        RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN                   = 38, // <Switch_Stmt> ::= switch '(' <expr> ')' <Case Block>
        RULE_CASEBLOCK_LBRACE_RBRACE                            = 39, // <Case Block> ::= '{' '}'
        RULE_CASEBLOCK_LBRACE_RBRACE2                           = 40, // <Case Block> ::= '{' <Case Clauses> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE3                           = 41, // <Case Block> ::= '{' <Case Clauses> <Default Clause> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE4                           = 42, // <Case Block> ::= '{' <Case Clauses> <Default Clause> <Case Clauses> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE5                           = 43, // <Case Block> ::= '{' <Default Clause> <Case Clauses> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE6                           = 44, // <Case Block> ::= '{' <Default Clause> '}'
        RULE_CASECLAUSES                                        = 45, // <Case Clauses> ::= <Case Clause>
        RULE_CASECLAUSES2                                       = 46, // <Case Clauses> ::= <Case Clauses> <Case Clause>
        RULE_CASECLAUSE_CASE_COLON                              = 47, // <Case Clause> ::= case <expr> ':' <stmt_list>
        RULE_CASECLAUSE_CASE_COLON2                             = 48, // <Case Clause> ::= case <expr> ':'
        RULE_DEFAULTCLAUSE_DEFAULT_COLON                        = 49, // <Default Clause> ::= default ':'
        RULE_DEFAULTCLAUSE_DEFAULT_COLON2                       = 50  // <Default Clause> ::= default ':' <stmt_list>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGITAL :
                //Digital
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASEBLOCK :
                //<Case Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASECLAUSE :
                //<Case Clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASECLAUSES :
                //<Case Clauses>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULTCLAUSE :
                //<Default Clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT :
                //<Switch_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <id> '=' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_END :
                //<if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_END_ELSE :
                //<if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End else <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_stmt> ::= For '(' <data> <assign> ';' <cond> ';' <step> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN :
                //<Switch_Stmt> ::= switch '(' <expr> ')' <Case Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE :
                //<Case Block> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE2 :
                //<Case Block> ::= '{' <Case Clauses> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE3 :
                //<Case Block> ::= '{' <Case Clauses> <Default Clause> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE4 :
                //<Case Block> ::= '{' <Case Clauses> <Default Clause> <Case Clauses> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE5 :
                //<Case Block> ::= '{' <Default Clause> <Case Clauses> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE6 :
                //<Case Block> ::= '{' <Default Clause> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSES :
                //<Case Clauses> ::= <Case Clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSES2 :
                //<Case Clauses> ::= <Case Clauses> <Case Clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSE_CASE_COLON :
                //<Case Clause> ::= case <expr> ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSE_CASE_COLON2 :
                //<Case Clause> ::= case <expr> ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULTCLAUSE_DEFAULT_COLON :
                //<Default Clause> ::= default ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULTCLAUSE_DEFAULT_COLON2 :
                //<Default Clause> ::= default ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
