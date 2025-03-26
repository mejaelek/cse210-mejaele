 import random
import os

class ScriptureReference:
    def __init__(self, book, chapter, start_verse, end_verse=None):
        self.book = book
        self.chapter = chapter
        self.start_verse = start_verse
        self.end_verse = end_verse

    def __str__(self):
        if self.end_verse:
            return f"{self.book} {self.chapter}:{self.start_verse}-{self.end_verse}"
        return f"{self.book} {self.chapter}:{self.start_verse}"

class Word:
    def __init__(self, text):
        self.text = text
        self.hidden = False
    
    def hide(self):
        self.hidden = True

    def __str__(self):
        return "_" * len(self.text) if self.hidden else self.text

class Scripture:
    def __init__(self, reference, text):
        self.reference = reference
        self.words = [Word(word) for word in text.split()]
    
    def hide_random_words(self, count=2):
        visible_words = [word for word in self.words if not word.hidden]
        if len(visible_words) > 0:
            words_to_hide = random.sample(visible_words, min(count, len(visible_words)))
            for word in words_to_hide:
                word.hide()
    
    def is_fully_hidden(self):
        return all(word.hidden for word in self.words)
    
    def display(self):
        os.system('cls' if os.name == 'nt' else 'clear')
        print(self.reference)
        print(" ".join(str(word) for word in self.words))

def load_scriptures_from_file(filename):
    scriptures = []
    with open(filename, "r") as file:
        for line in file:
            parts = line.strip().split("|", 1)
            if len(parts) == 2:
                ref_text, scripture_text = parts
                book, chapter_verse = ref_text.rsplit(" ", 1)
                if "-" in chapter_verse:
                    chapter, verses = chapter_verse.split(":")
                    start_verse, end_verse = map(int, verses.split("-"))
                    reference = ScriptureReference(book, chapter, start_verse, end_verse)
                else:
                    chapter, start_verse = chapter_verse.split(":")
                    reference = ScriptureReference(book, chapter, int(start_verse))
                
                scriptures.append(Scripture(reference, scripture_text))
    return scriptures

def main():
    scriptures = load_scriptures_from_file("scriptures.txt")
    scripture = random.choice(scriptures)  # Select a random scripture
    
    while True:
        scripture.display()
        user_input = input("Press Enter to continue or type 'quit' to exit: ").strip().lower()
        if user_input == "quit":
            break
        scripture.hide_random_words()
        if scripture.is_fully_hidden():
            scripture.display()
            break

if __name__ == "__main__":
    main()
