using System;
using System.Collections;
using System.Collections.Generic;


public class State {
	public string name;
	public bool isFinal;
	public Dictionary<string, List<String>> arrows;

	public State (string name, bool isFinal, Dictionary<string, List<String>> arrows) {
		this.name = name;
		this.isFinal = isFinal;
		this.arrows = arrows;
	}
}

public class Machine {
	public List<string> alphabet;
	public State start;
	public Dictionary<string, State> states;
	public string description;

	public Machine(State start, List<string> alphabet, Dictionary<string, State> states, string description) {
		this.start = start;
		this.alphabet = alphabet;
		this.states = states;
		this.description = description;
	}
	public Machine () {
		this.start = null;
		this.alphabet = null;
		this.states = null;
		this.description = null;
	}

	public bool executeSteps(Machine m, string currState, string input, int index) {
		if (input.Length == index) {
			if (m.states[currState].isFinal == true) {
				return true;
			} else {
				return false;
			}
		}

		foreach (string transition in m.states[currState].arrows.Keys) {
			if (transition == input[index].ToString()) {
				foreach (string value in m.states[currState].arrows[transition]) {
					if (executeSteps(m, value, input, index + 1)) {
						return true;
					}
				}
			}
		}
		return false;
	}
}