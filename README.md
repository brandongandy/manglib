# Mang
A Markov chain-based name and word generator

## What it Does
Mang generates words and names based on input you give it. It uses the input to generate words that sound like they came from the given language without being real words, useful for generating NPC names or giving yourself inspiration for a conlang.

The library has a repository of presets available, sourced from all over the world, including some preexisting fantasy sources. It's easy to switch between sources, or run multiple generators at once. It's also easy to give the generator your own input, if you don't want to use the presets.

## How to Use
After downloading and linking the project to your own, Mang is simple to use:
```
var ng = new NameGenerator();
var wordList = ng.GenerateWordList();
```

Sensible defaults are provided so you only have to worry about picking what "type" of word to generate. To change the type, you can do:
```
ng.SwitchSource(Navajo.Surname);
```

Then generate a new word list.

### Custom Input
To give Mang some custom input from which to generate new words, simply construct your own list of strings and pass them into the `SwitchSource` method:
```
var myNewList = new List<string>();
// populate with ~things~
ng.SwitchSource(myNewList);
```

### Token Length (n-grams)
The Markov chain generator works off tokens, or n-grams, consisting of *x*-character long substrings from the input. Imagine you pass in a word like this `imagine` with a token length of `3`. The Markov data will generate tokens from that string like so:
```
ima
mag
agi
gin
ine
```

So, you can imagine that the token length configured has some impact on the output's similarity to the input. In my own use, I've found a length of `3` is typically good enough for unique, but closely related, output. But you can set this yourself when you update your `NameGenerator` source, with an override:
```
ng.SwitchSource(Navajo.Surname, tokenLength: 5);
ng.SwitchSource(myNewList, tokenLength: 2);
```

Currently, the value of the `tokenLength` parameter is clamped between 1 and 5 inclusively.

## Planned Work
In the future I would like to do a few things with this:

* Add a string distance comparison to check input and output similarity, and toss output that's too similar
* Add a "grammar" builder to make sure output follows grammar rules of the input (vowel-consonant pairing, for example)
* ???

## A Note on the Presets
Categorization is a Hard Problem. I've categorized the names in these presets to the best of my ability, but if any are in the wrong category or the category is mislabeled, please correct me with a comment, email, or pull request, and I will fix things.

## Special Thanks
The majority of the included presets were gathered from resources like [Kate Monk's Onomastikon](https://tekeli.li/onomastikon/index.html),