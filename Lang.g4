grammar Lang;

file
    : method* EOF
    ;
method: 'def' NAME parameter_declaration block;
parameter_declaration: '(' NAME? (',' NAME)* ')';
block: '{' statement* '}';

statement: (return_statement) (';' | NEWLINE);
return_statement: 'return' expression;

expression
    : paraphrase
    | expression MULTIPLY expression
    | expression DIVIDE expression
    | expression MODULO expression

    | expression ADD expression
    | expression SUBSTRACT expression
    | NUMBER
    | NAME
    ;

paraphrase: '(' expression ')';


NAME: [a-zA-Z_][a-zA-Z_0-9]*;
NUMBER: [-+]?[0-9_]+;

WHITESPACE: [ \t]+ -> skip;
NEWLINE: [\n\r]+ -> skip;

ADD:         '+';
SUBSTRACT:   '-';
MULTIPLY:    '*';
DIVIDE:      '/';
MODULO:      '%';
