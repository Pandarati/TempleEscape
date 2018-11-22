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
		mainDFA = buildLevelDFA();
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
		machines_1.Add(m5);

	}

	protected static Machine buildLevelDFA () {
		loadDFAPieces();
		System.Random rnd = new System.Random();
		int m1_selection = rnd.Next(3);
		int m2_selection = rnd.Next(2);
		Console.WriteLine (m2_selection);
		Console.WriteLine (m1_selection);
		Machine dfa1 = machines_1[m1_selection];
		Machine dfa2 = machines_2[m2_selection];

		Dictionary<string, State> states = new Dictionary<string, State> ();
		List<string> alphabet = dfa1.alphabet;
//		for (int i = 0; i < dfa1.states.Count; i++) {
//			for (int j = 0; j < dfa2.states.Count; j++) {
//				string name = dfa1.states[i].name + dfa2.states[j].name;
//				bool isFinal = dfa1.states[i].isFinal && dfa2.states[j].isFinal;
//
//				Hashtable arrows = new Hashtable();
//				List<string> pound_transition = new List<string>() {dfa1.states[i].arrows["#"] + dfa2.states[j].arrows["#"]};
//				List<string> star_transition = new List<string>() {dfa1.states[i].arrows["*"] + dfa2.states[j].arrows["*"]};
//				arrows.Add("#", pound_transition);
//				arrows.Add("*", star_transition);
//				states.Add(new State(name, isFinal, arrows));
//			}
//		}

		foreach(State dfa1_entry in dfa1.states.Values){
			foreach(State dfa2_entry in dfa2.states.Values){
				string name = dfa1_entry.name + dfa2_entry.name;
				bool isFinal = dfa1_entry.isFinal && dfa2_entry.isFinal;

				List<string> pound_transition = new List<string>() {dfa1_entry.arrows["#"][0] + dfa2_entry.arrows["#"][0]};
				List<string> star_transition = new List<string>() {dfa1_entry.arrows["*"][0] + dfa2_entry.arrows["*"][0]};
//				Console.WriteLine (dfa1_entry.arrows["#"][0]);
//				Console.WriteLine (dfa2_entry.arrows["#"][0]);
//				Console.WriteLine (pound_transition[0]);
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
}
