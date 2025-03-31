import time
import random
import json
import os

class MindfulnessActivity:
    def __init__(self, name, description):
        self.name = name
        self.description = description

    def start(self, duration):
        print(f'\nStarting {self.name}...')
        print(self.description)
        print(f'This activity will last {duration} seconds. Prepare to begin...')
        self.pause_with_animation(3)

    def end(self, duration):
        print(f'\nGood job! You have completed the {self.name} for {duration} seconds.')
        self.pause_with_animation(3)

    def pause_with_animation(self, seconds):
        for i in range(seconds):
            print('.', end='', flush=True)
            time.sleep(1)
        print()

class BreathingActivity(MindfulnessActivity):
    def perform_activity(self, duration):
        self.start(duration)
        for _ in range(duration // 4):
            print("Breathe in...", end=" ")
            self.breathing_animation()
            print("Breathe out...", end=" ")
            self.breathing_animation()
        self.end(duration)

    def breathing_animation(self):
        for i in range(5):
            print("*" * i, end="\r", flush=True)
            time.sleep(0.5)
        for i in range(5, 0, -1):
            print("*" * i, end="\r", flush=True)
            time.sleep(0.5)

class ReflectionActivity(MindfulnessActivity):
    prompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]

    def perform_activity(self, duration):
        self.start(duration)
        used_prompts = set()
        while len(used_prompts) < len(self.prompts):
            prompt = random.choice(self.prompts)
            if prompt not in used_prompts:
                used_prompts.add(prompt)
                print(f'Prompt: {prompt}')
                self.pause_with_animation(3)
        self.end(duration)

class ListingActivity(MindfulnessActivity):
    prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    ]

    def perform_activity(self, duration):
        self.start(duration)
        prompt = random.choice(self.prompts)
        print(f'Prompt: {prompt}')
        items = []
        start_time = time.time()
        while time.time() - start_time < duration:
            item = input("List an item: ")
            if item:
                items.append(item)
        print(f'You listed {len(items)} items.')
        self.end(duration)


def save_log(activity_name):
    log_file = "activity_log.json"
    log = {}
    if os.path.exists(log_file):
        with open(log_file, "r") as f:
            log = json.load(f)
    log[activity_name] = log.get(activity_name, 0) + 1
    with open(log_file, "w") as f:
        json.dump(log, f)


def main():
    activities = {
        '1': BreathingActivity("Breathing", "This activity helps you relax by guiding your breathing."),
        '2': ReflectionActivity("Reflection", "This activity helps you reflect on your strengths and experiences."),
        '3': ListingActivity("Listing", "This activity helps you list positive aspects of your life.")
    }

    while True:
        print("\nMindfulness App")
        print("1. Breathing Activity")
        print("2. Reflection Activity")
        print("3. Listing Activity")
        print("4. Exit")
        choice = input("Choose an activity: ")

        if choice == '4':
            print("Goodbye! Stay mindful!")
            break
        elif choice in activities:
            duration = int(input("Enter duration (in seconds): "))
            activities[choice].perform_activity(duration)
            save_log(activities[choice].name)
        else:
            print("Invalid choice. Please try again.")


if __name__ == "__main__":
    main()
