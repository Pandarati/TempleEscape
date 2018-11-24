using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class gameBoardScript : MonoBehaviour {

	    public Text RulesText;

			protected static List<Machine> machines_1 = new List<Machine>();
			protected static List<Machine> machines_2 = new List<Machine>();
			protected static Machine mainDFA = new Machine();

// 	public static void Main (string[] args) {
// 		mainDFA = buildLevelDFA();
// //		Console.WriteLine (mainDFA.start.name);
// //		foreach (string key in mainDFA.states.Keys) {
// //			Console.WriteLine (key);
// //		}
// //		foreach (Machine m in machines_1) {
// //			Console.WriteLine (m.description);
// //			string input = "*###*#";
// //			int index = 0;
// //			Console.WriteLine (m.start.name);
// //					foreach (string key in m.states.Keys) {
// //						Console.WriteLine (key + " keyyy");
// //					}
// //			foreach (State key in m.states.Values) {
// //				Console.WriteLine (key.name + "   name");
// //				foreach(string sym in key.arrows.Keys) {
// //					Console.WriteLine(key.arrows[sym][0] + "  " + sym + "  " + key.name);
// //				}
// //			}
// //			Console.WriteLine (m.executeSteps (m, m.start.name, input, index));
// //		}
//
// 	}

	// Use this for initialization
	void Start () {
		loadDFAPieces();

		System.Random rnd = new System.Random();
		int m1_selection = rnd.Next(6);
	  int m2_selection = rnd.Next(6);

	  Console.WriteLine (machines_1.Count);
	  Console.WriteLine (machines_2.Count);
		Console.WriteLine (m1_selection);
		Console.WriteLine (m2_selection);

		mainDFA = buildLevelDFA(machines_1[m1_selection], machines_2[m2_selection]);
		mainDFA = buildLevelDFADifficult();
		RulesText.text = mainDFA.description;
		Console.WriteLine(mainDFA.description);
	}

	// Update is called once per frame
	protected static void Update () {
		string input = "*###*#";
		int index = 0;
		Console.WriteLine(mainDFA.executeSteps(mainDFA, mainDFA.start.name, input, index));
	}

	protected static void loadDFAPieces() {
		List<string> alphabet = new List<string>() {"#", "*"};

		//ends with #
		Dictionary<string, List<String>> arrows = new Dictionary<string, List<String>>();
		List<string> pound_transition = new List<string>() {"q1"};
		List<string> star_transition = new List<string>() {"q0"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q0 = new State("q0", false, arrows);
		State q1 = new State("q1", true, arrows);
		Dictionary<string, State> states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}};
		Machine m1 = new Machine(q0, alphabet, states, "- your last step must be on a # tile");
		machines_1.Add(m1);

		//string with odd number of *
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q0"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q0"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}};
		Machine m2 = new Machine(q0, alphabet, states, "- you must make an odd number of steps on * tiles");
		machines_2.Add(m2);

		//one or two #
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q0"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q2 = new State("q2", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q3 = new State("q3", false, arrows);

		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}, {"q3", q3}};
		Machine m3 = new Machine(q0, alphabet, states, "- you must make one or two steps on a # tile");
		machines_1.Add(m3);

		//even length
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q0"};
		star_transition = new List<string>() {"q0"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}};
		Machine m4 = new Machine(q0, alphabet, states, "- you must make an even number of steps");
		machines_2.Add(m4);

		//starts with *
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}};
		Machine m5 = new Machine(q0, alphabet, states, "- you must start on a * tile");
		machines_2.Add(m5);

		//does not contain substring *#
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q0"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}};
		Machine m6 = new Machine(q0, alphabet, states, "- you cannot step on a # tile after a * tile");
		machines_2.Add(m6);

		//atleast 8 steps
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q4"};
		star_transition = new List<string>() {"q4"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q3 = new State("q3", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q5"};
		star_transition = new List<string>() {"q5"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q4 = new State("q4", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q6"};
		star_transition = new List<string>() {"q6"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q5 = new State("q5", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q7"};
		star_transition = new List<string>() {"q7"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q6 = new State("q6", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q8"};
		star_transition = new List<string>() {"q8"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q7 = new State("q7", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q8"};
		star_transition = new List<string>() {"q8"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q8 = new State("q8", true, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2},
			{"q3", q3}, {"q4", q4}, {"q5", q5}, {"q6", q6}, {"q7", q7}, {"q8", q8}};
		Machine m7 = new Machine(q0, alphabet, states, "- you must make atleast 8 steps");
		machines_2.Add(m7);

		//third step must be on a * tile
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q4"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q3 = new State("q3", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q4"};
		star_transition = new List<string>() {"q4"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q4 = new State("q4", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}, {"q3", q3}, {"q4", q4}};
		Machine m8 = new Machine(q0, alphabet, states, "- you cannot step on a # tile after a * tile");
		machines_2.Add(m8);

		//every odd numbered step should be on a # tile
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q3 = new State("q3", true, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}, {"q3", q3}};
		Machine m9 = new Machine(q0, alphabet, states, "- every odd numbered step must be on a # tile");
		machines_1.Add(m9);

		//at most one step on a # tile
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q3 = new State("q3", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}, {"q3", q3}};
		Machine m10 = new Machine(q0, alphabet, states, "- you can only step on a # tile once");
		machines_1.Add(m10);

		//exactly 12 tiles
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q1"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q3"};
		star_transition = new List<string>() {"q3"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q2", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q4"};
		star_transition = new List<string>() {"q4"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q3 = new State("q3", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q5"};
		star_transition = new List<string>() {"q5"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q4 = new State("q4", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q6"};
		star_transition = new List<string>() {"q6"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q5 = new State("q5", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q7"};
		star_transition = new List<string>() {"q7"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q6 = new State("q6", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q8"};
		star_transition = new List<string>() {"q8"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q7 = new State("q7", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q9"};
		star_transition = new List<string>() {"q9"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q8 = new State("q8", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q10"};
		star_transition = new List<string>() {"q10"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q9 = new State("q9", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q11"};
		star_transition = new List<string>() {"q11"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q10 = new State("q10", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q12"};
		star_transition = new List<string>() {"q12"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q11 = new State("q11", false, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q13"};
		star_transition = new List<string>() {"q13"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q12 = new State("q12", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q13"};
		star_transition = new List<string>() {"q13"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		State q13 = new State("q13", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2},
			{"q3", q3}, {"q4", q4}, {"q5", q5}, {"q6", q6}, {"q7", q7}, {"q8", q8},
			{"q9", q9}, {"q10", q10}, {"q11", q11}, {"q12", q12}, {"q13", q13}};
		Machine m11 = new Machine(q0, alphabet, states, "- you must make atleast 8 steps");
		machines_1.Add(m11);

		//does not contain the substring ##
		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q1"};
		star_transition = new List<string>() {"q0"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q0 = new State("q0", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q0"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q1 = new State("q1", true, arrows);

		arrows = new Dictionary<string, List<String>>();
		pound_transition = new List<string>() {"q2"};
		star_transition = new List<string>() {"q2"};
		arrows.Add("#", pound_transition);
		arrows.Add("*", star_transition);
		q2 = new State("q3", false, arrows);
		states = new Dictionary<string, State>() {{"q0", q0}, {"q1", q1}, {"q2", q2}};
		Machine m12 = new Machine(q0, alphabet, states, "- you cannot step on two # tiles consecutively");
		machines_1.Add (m12);
	}

	protected static Machine buildLevelDFA (Machine dfa1, Machine dfa2) {

		Dictionary<string, State> states = new Dictionary<string, State> ();
		List<string> alphabet = dfa1.alphabet;

		foreach(State dfa1_entry in dfa1.states.Values){
			foreach(State dfa2_entry in dfa2.states.Values){

				string name = dfa1_entry.name + dfa2_entry.name;
				bool isFinal = dfa1_entry.isFinal && dfa2_entry.isFinal;
				List<string> pound_transition = new List<string>() {dfa1_entry.arrows["#"][0] + dfa2_entry.arrows["#"][0]};
				List<string> star_transition = new List<string>() {dfa1_entry.arrows["*"][0] + dfa2_entry.arrows["*"][0]};
				Dictionary<string, List<String>> arrows = new Dictionary<string, List<String>>();
				arrows.Add("#", pound_transition);
				arrows.Add("*", star_transition);
				states.Add(name, new State(name, isFinal, arrows));
			}
		}
		List<State> list = new List<State>();
		list = states.Values.ToList();
		return new Machine(list[0], alphabet, states, dfa1.description + "\n" + dfa2.description);
	}

	protected static Machine buildLevelDFADifficult () {
			List<Machine> dfas_1 = new List<Machine>();
			List<Machine> dfas_2 = new List<Machine>();
			List<Machine> dfas_3 = new List<Machine>();
			System.Random rnd = new System.Random();

			for (int i = 0; i < machines_1.Count; i++) {
				if (i == 5) {
					dfas_1.Add (machines_1[i]);
				} else {
					dfas_2.Add (machines_1[i]);
				}
			}
			for (int i = 0; i < machines_2.Count; i++) {
				if (i == 1 || i == 3) {
					dfas_1.Add (machines_2[i]);
				} else {
					dfas_3.Add (machines_2[i]);
				}
			}

			int dfa1_selection = rnd.Next(3);
			int dfa2_selection = rnd.Next(5);
			int dfa3_selection = rnd.Next(4);

			Machine temp = buildLevelDFA (dfas_1 [dfa1_selection], dfas_2 [dfa2_selection]);
			return buildLevelDFA (temp, dfas_3 [dfa3_selection]);
		}
}
