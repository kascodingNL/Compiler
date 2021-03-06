//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/superblaubeere27/Desktop/compilerTest/Compiler/Compiler\Lang.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Parser {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class LangParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, NAME=11, NUMBER=12, WHITESPACE=13, NEWLINE=14, ADD=15, SUBSTRACT=16, 
		MULTIPLY=17, DIVIDE=18, MODULO=19;
	public const int
		RULE_file = 0, RULE_method = 1, RULE_parameter_declaration = 2, RULE_block = 3, 
		RULE_var_declaration = 4, RULE_assignment = 5, RULE_statement = 6, RULE_return_statement = 7, 
		RULE_expression = 8, RULE_paraphrase = 9;
	public static readonly string[] ruleNames = {
		"file", "method", "parameter_declaration", "block", "var_declaration", 
		"assignment", "statement", "return_statement", "expression", "paraphrase"
	};

	private static readonly string[] _LiteralNames = {
		null, "'def'", "'('", "','", "')'", "'{'", "'}'", "'var'", "'='", "';'", 
		"'return'", null, null, null, null, "'+'", "'-'", "'*'", "'/'", "'%'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, "NAME", 
		"NUMBER", "WHITESPACE", "NEWLINE", "ADD", "SUBSTRACT", "MULTIPLY", "DIVIDE", 
		"MODULO"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Lang.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static LangParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public LangParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public LangParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class FileContext : ParserRuleContext {
		public ITerminalNode Eof() { return GetToken(LangParser.Eof, 0); }
		public MethodContext[] method() {
			return GetRuleContexts<MethodContext>();
		}
		public MethodContext method(int i) {
			return GetRuleContext<MethodContext>(i);
		}
		public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_file; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFile(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FileContext file() {
		FileContext _localctx = new FileContext(Context, State);
		EnterRule(_localctx, 0, RULE_file);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 23;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__0) {
				{
				{
				State = 20; method();
				}
				}
				State = 25;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 26; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MethodContext : ParserRuleContext {
		public ITerminalNode NAME() { return GetToken(LangParser.NAME, 0); }
		public Parameter_declarationContext parameter_declaration() {
			return GetRuleContext<Parameter_declarationContext>(0);
		}
		public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		public MethodContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_method; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMethod(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MethodContext method() {
		MethodContext _localctx = new MethodContext(Context, State);
		EnterRule(_localctx, 2, RULE_method);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 28; Match(T__0);
			State = 29; Match(NAME);
			State = 30; parameter_declaration();
			State = 31; block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Parameter_declarationContext : ParserRuleContext {
		public ITerminalNode[] NAME() { return GetTokens(LangParser.NAME); }
		public ITerminalNode NAME(int i) {
			return GetToken(LangParser.NAME, i);
		}
		public Parameter_declarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_parameter_declaration; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParameter_declaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Parameter_declarationContext parameter_declaration() {
		Parameter_declarationContext _localctx = new Parameter_declarationContext(Context, State);
		EnterRule(_localctx, 4, RULE_parameter_declaration);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 33; Match(T__1);
			State = 35;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==NAME) {
				{
				State = 34; Match(NAME);
				}
			}

			State = 41;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 37; Match(T__2);
				State = 38; Match(NAME);
				}
				}
				State = 43;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 44; Match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockContext : ParserRuleContext {
		public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_block; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlock(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(Context, State);
		EnterRule(_localctx, 6, RULE_block);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 46; Match(T__4);
			State = 50;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__6) | (1L << T__9) | (1L << NAME))) != 0)) {
				{
				{
				State = 47; statement();
				}
				}
				State = 52;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 53; Match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Var_declarationContext : ParserRuleContext {
		public ITerminalNode NAME() { return GetToken(LangParser.NAME, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public Var_declarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_var_declaration; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVar_declaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Var_declarationContext var_declaration() {
		Var_declarationContext _localctx = new Var_declarationContext(Context, State);
		EnterRule(_localctx, 8, RULE_var_declaration);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 55; Match(T__6);
			State = 56; Match(NAME);
			State = 59;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__7) {
				{
				State = 57; Match(T__7);
				State = 58; expression(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AssignmentContext : ParserRuleContext {
		public ITerminalNode NAME() { return GetToken(LangParser.NAME, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assignment; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssignment(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AssignmentContext assignment() {
		AssignmentContext _localctx = new AssignmentContext(Context, State);
		EnterRule(_localctx, 10, RULE_assignment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 61; Match(NAME);
			State = 62; Match(T__7);
			State = 63; expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		public ITerminalNode NEWLINE() { return GetToken(LangParser.NEWLINE, 0); }
		public Return_statementContext return_statement() {
			return GetRuleContext<Return_statementContext>(0);
		}
		public Var_declarationContext var_declaration() {
			return GetRuleContext<Var_declarationContext>(0);
		}
		public AssignmentContext assignment() {
			return GetRuleContext<AssignmentContext>(0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(Context, State);
		EnterRule(_localctx, 12, RULE_statement);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 68;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__9:
				{
				State = 65; return_statement();
				}
				break;
			case T__6:
				{
				State = 66; var_declaration();
				}
				break;
			case NAME:
				{
				State = 67; assignment();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			State = 70;
			_la = TokenStream.LA(1);
			if ( !(_la==T__8 || _la==NEWLINE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Return_statementContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public Return_statementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_return_statement; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitReturn_statement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Return_statementContext return_statement() {
		Return_statementContext _localctx = new Return_statementContext(Context, State);
		EnterRule(_localctx, 14, RULE_return_statement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 72; Match(T__9);
			State = 73; expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ParaphraseContext paraphrase() {
			return GetRuleContext<ParaphraseContext>(0);
		}
		public AssignmentContext assignment() {
			return GetRuleContext<AssignmentContext>(0);
		}
		public ITerminalNode NUMBER() { return GetToken(LangParser.NUMBER, 0); }
		public ITerminalNode NAME() { return GetToken(LangParser.NAME, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode MULTIPLY() { return GetToken(LangParser.MULTIPLY, 0); }
		public ITerminalNode DIVIDE() { return GetToken(LangParser.DIVIDE, 0); }
		public ITerminalNode MODULO() { return GetToken(LangParser.MODULO, 0); }
		public ITerminalNode ADD() { return GetToken(LangParser.ADD, 0); }
		public ITerminalNode SUBSTRACT() { return GetToken(LangParser.SUBSTRACT, 0); }
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 16;
		EnterRecursionRule(_localctx, 16, RULE_expression, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 80;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,6,Context) ) {
			case 1:
				{
				State = 76; paraphrase();
				}
				break;
			case 2:
				{
				State = 77; assignment();
				}
				break;
			case 3:
				{
				State = 78; Match(NUMBER);
				}
				break;
			case 4:
				{
				State = 79; Match(NAME);
				}
				break;
			}
			Context.Stop = TokenStream.LT(-1);
			State = 99;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,8,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 97;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,7,Context) ) {
					case 1:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 82;
						if (!(Precpred(Context, 8))) throw new FailedPredicateException(this, "Precpred(Context, 8)");
						State = 83; Match(MULTIPLY);
						State = 84; expression(9);
						}
						break;
					case 2:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 85;
						if (!(Precpred(Context, 7))) throw new FailedPredicateException(this, "Precpred(Context, 7)");
						State = 86; Match(DIVIDE);
						State = 87; expression(8);
						}
						break;
					case 3:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 88;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 89; Match(MODULO);
						State = 90; expression(7);
						}
						break;
					case 4:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 91;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 92; Match(ADD);
						State = 93; expression(6);
						}
						break;
					case 5:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 94;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 95; Match(SUBSTRACT);
						State = 96; expression(5);
						}
						break;
					}
					} 
				}
				State = 101;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,8,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class ParaphraseContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ParaphraseContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_paraphrase; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ILangVisitor<TResult> typedVisitor = visitor as ILangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParaphrase(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ParaphraseContext paraphrase() {
		ParaphraseContext _localctx = new ParaphraseContext(Context, State);
		EnterRule(_localctx, 18, RULE_paraphrase);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 102; Match(T__1);
			State = 103; expression(0);
			State = 104; Match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 8: return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 8);
		case 1: return Precpred(Context, 7);
		case 2: return Precpred(Context, 6);
		case 3: return Precpred(Context, 5);
		case 4: return Precpred(Context, 4);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x15', 'm', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x3', '\x2', '\a', '\x2', '\x18', '\n', '\x2', '\f', '\x2', '\xE', '\x2', 
		'\x1B', '\v', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x5', '\x4', '&', '\n', '\x4', '\x3', '\x4', '\x3', '\x4', '\a', 
		'\x4', '*', '\n', '\x4', '\f', '\x4', '\xE', '\x4', '-', '\v', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', '\x33', 
		'\n', '\x5', '\f', '\x5', '\xE', '\x5', '\x36', '\v', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x5', '\x6', '>', '\n', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x5', '\b', 'G', 
		'\n', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x5', '\n', 'S', '\n', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\a', '\n', '\x64', '\n', '\n', '\f', '\n', '\xE', '\n', 'g', '\v', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', 
		'\x2', '\x3', '\x12', '\f', '\x2', '\x4', '\x6', '\b', '\n', '\f', '\xE', 
		'\x10', '\x12', '\x14', '\x2', '\x3', '\x4', '\x2', '\v', '\v', '\x10', 
		'\x10', '\x2', 'q', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x4', 
		'\x1E', '\x3', '\x2', '\x2', '\x2', '\x6', '#', '\x3', '\x2', '\x2', '\x2', 
		'\b', '\x30', '\x3', '\x2', '\x2', '\x2', '\n', '\x39', '\x3', '\x2', 
		'\x2', '\x2', '\f', '?', '\x3', '\x2', '\x2', '\x2', '\xE', '\x46', '\x3', 
		'\x2', '\x2', '\x2', '\x10', 'J', '\x3', '\x2', '\x2', '\x2', '\x12', 
		'R', '\x3', '\x2', '\x2', '\x2', '\x14', 'h', '\x3', '\x2', '\x2', '\x2', 
		'\x16', '\x18', '\x5', '\x4', '\x3', '\x2', '\x17', '\x16', '\x3', '\x2', 
		'\x2', '\x2', '\x18', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x19', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x19', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'\x1A', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\x1D', '\a', '\x2', '\x2', '\x3', '\x1D', '\x3', 
		'\x3', '\x2', '\x2', '\x2', '\x1E', '\x1F', '\a', '\x3', '\x2', '\x2', 
		'\x1F', ' ', '\a', '\r', '\x2', '\x2', ' ', '!', '\x5', '\x6', '\x4', 
		'\x2', '!', '\"', '\x5', '\b', '\x5', '\x2', '\"', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '#', '%', '\a', '\x4', '\x2', '\x2', '$', '&', '\a', '\r', 
		'\x2', '\x2', '%', '$', '\x3', '\x2', '\x2', '\x2', '%', '&', '\x3', '\x2', 
		'\x2', '\x2', '&', '+', '\x3', '\x2', '\x2', '\x2', '\'', '(', '\a', '\x5', 
		'\x2', '\x2', '(', '*', '\a', '\r', '\x2', '\x2', ')', '\'', '\x3', '\x2', 
		'\x2', '\x2', '*', '-', '\x3', '\x2', '\x2', '\x2', '+', ')', '\x3', '\x2', 
		'\x2', '\x2', '+', ',', '\x3', '\x2', '\x2', '\x2', ',', '.', '\x3', '\x2', 
		'\x2', '\x2', '-', '+', '\x3', '\x2', '\x2', '\x2', '.', '/', '\a', '\x6', 
		'\x2', '\x2', '/', '\a', '\x3', '\x2', '\x2', '\x2', '\x30', '\x34', '\a', 
		'\a', '\x2', '\x2', '\x31', '\x33', '\x5', '\xE', '\b', '\x2', '\x32', 
		'\x31', '\x3', '\x2', '\x2', '\x2', '\x33', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '\x34', '\x32', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '\x37', '\x3', '\x2', '\x2', '\x2', '\x36', 
		'\x34', '\x3', '\x2', '\x2', '\x2', '\x37', '\x38', '\a', '\b', '\x2', 
		'\x2', '\x38', '\t', '\x3', '\x2', '\x2', '\x2', '\x39', ':', '\a', '\t', 
		'\x2', '\x2', ':', '=', '\a', '\r', '\x2', '\x2', ';', '<', '\a', '\n', 
		'\x2', '\x2', '<', '>', '\x5', '\x12', '\n', '\x2', '=', ';', '\x3', '\x2', 
		'\x2', '\x2', '=', '>', '\x3', '\x2', '\x2', '\x2', '>', '\v', '\x3', 
		'\x2', '\x2', '\x2', '?', '@', '\a', '\r', '\x2', '\x2', '@', '\x41', 
		'\a', '\n', '\x2', '\x2', '\x41', '\x42', '\x5', '\x12', '\n', '\x2', 
		'\x42', '\r', '\x3', '\x2', '\x2', '\x2', '\x43', 'G', '\x5', '\x10', 
		'\t', '\x2', '\x44', 'G', '\x5', '\n', '\x6', '\x2', '\x45', 'G', '\x5', 
		'\f', '\a', '\x2', '\x46', '\x43', '\x3', '\x2', '\x2', '\x2', '\x46', 
		'\x44', '\x3', '\x2', '\x2', '\x2', '\x46', '\x45', '\x3', '\x2', '\x2', 
		'\x2', 'G', 'H', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\t', '\x2', '\x2', 
		'\x2', 'I', '\xF', '\x3', '\x2', '\x2', '\x2', 'J', 'K', '\a', '\f', '\x2', 
		'\x2', 'K', 'L', '\x5', '\x12', '\n', '\x2', 'L', '\x11', '\x3', '\x2', 
		'\x2', '\x2', 'M', 'N', '\b', '\n', '\x1', '\x2', 'N', 'S', '\x5', '\x14', 
		'\v', '\x2', 'O', 'S', '\x5', '\f', '\a', '\x2', 'P', 'S', '\a', '\xE', 
		'\x2', '\x2', 'Q', 'S', '\a', '\r', '\x2', '\x2', 'R', 'M', '\x3', '\x2', 
		'\x2', '\x2', 'R', 'O', '\x3', '\x2', '\x2', '\x2', 'R', 'P', '\x3', '\x2', 
		'\x2', '\x2', 'R', 'Q', '\x3', '\x2', '\x2', '\x2', 'S', '\x65', '\x3', 
		'\x2', '\x2', '\x2', 'T', 'U', '\f', '\n', '\x2', '\x2', 'U', 'V', '\a', 
		'\x13', '\x2', '\x2', 'V', '\x64', '\x5', '\x12', '\n', '\v', 'W', 'X', 
		'\f', '\t', '\x2', '\x2', 'X', 'Y', '\a', '\x14', '\x2', '\x2', 'Y', '\x64', 
		'\x5', '\x12', '\n', '\n', 'Z', '[', '\f', '\b', '\x2', '\x2', '[', '\\', 
		'\a', '\x15', '\x2', '\x2', '\\', '\x64', '\x5', '\x12', '\n', '\t', ']', 
		'^', '\f', '\a', '\x2', '\x2', '^', '_', '\a', '\x11', '\x2', '\x2', '_', 
		'\x64', '\x5', '\x12', '\n', '\b', '`', '\x61', '\f', '\x6', '\x2', '\x2', 
		'\x61', '\x62', '\a', '\x12', '\x2', '\x2', '\x62', '\x64', '\x5', '\x12', 
		'\n', '\a', '\x63', 'T', '\x3', '\x2', '\x2', '\x2', '\x63', 'W', '\x3', 
		'\x2', '\x2', '\x2', '\x63', 'Z', '\x3', '\x2', '\x2', '\x2', '\x63', 
		']', '\x3', '\x2', '\x2', '\x2', '\x63', '`', '\x3', '\x2', '\x2', '\x2', 
		'\x64', 'g', '\x3', '\x2', '\x2', '\x2', '\x65', '\x63', '\x3', '\x2', 
		'\x2', '\x2', '\x65', '\x66', '\x3', '\x2', '\x2', '\x2', '\x66', '\x13', 
		'\x3', '\x2', '\x2', '\x2', 'g', '\x65', '\x3', '\x2', '\x2', '\x2', 'h', 
		'i', '\a', '\x4', '\x2', '\x2', 'i', 'j', '\x5', '\x12', '\n', '\x2', 
		'j', 'k', '\a', '\x6', '\x2', '\x2', 'k', '\x15', '\x3', '\x2', '\x2', 
		'\x2', '\v', '\x19', '%', '+', '\x34', '=', '\x46', 'R', '\x63', '\x65',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Parser
