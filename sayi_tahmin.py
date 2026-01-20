import random
import json
import tkinter as tk
from tkinter import messagebox

class NumberGame:
    def __init__(self, root):
        self.root = root
        self.root.title("Sayı Tahmin Oyunu")
        self.root.geometry("300x400")
        self.number = random.randint(1, 100)
        self.attempts = 0
        self.history = []
        self.high_score = self.load_high_score()

        tk.Label(root, text="1 ile 100 arasında bir sayı tahmin et!", 
                font=("Arial", 12)).pack(pady=10)
        
        self.guess_entry = tk.Entry(root, width=10)
        self.guess_entry.pack(pady=5)
        
        tk.Button(root, text="Tahmin Et", command=self.check_guess).pack(pady=5)
        
        self.result_label = tk.Label(root, text="", font=("Arial", 10))
        self.result_label.pack(pady=5)
        
        self.history_label = tk.Label(root, text="Tahmin Geçmişi:", font=("Arial", 10))
        self.history_label.pack(pady=5)
        
        self.history_text = tk.Text(root, height=5, width=30)
        self.history_text.pack(pady=5)
        
        self.high_score_label = tk.Label(root, text=f"En İyi Skor: {self.high_score or 'Yok'}", 
                                       font=("Arial", 10))
        self.high_score_label.pack(pady=5)
        
        tk.Button(root, text="Yeni Oyun", command=self.new_game).pack(pady=5)

    def load_high_score(self):
        try:
            with open("high_score.json", "r") as file:
                data = json.load(file)
                return data.get("high_score", None)
        except FileNotFoundError:
            return None

    def save_high_score(self):
        with open("high_score.json", "w") as file:
            json.dump({"high_score": self.high_score}, file)

    def check_guess(self):
        try:
            guess = int(self.guess_entry.get())
            self.attempts += 1
            self.history.append(guess)
            self.history_text.delete(1.0, tk.END)
            self.history_text.insert(tk.END, "\n".join(map(str, self.history)))
            
            if guess < self.number:
                self.result_label.config(text="Daha büyük bir sayı gir!")
            elif guess > self.number:
                self.result_label.config(text="Daha küçük bir sayı gir!")
            else:
                self.result_label.config(text=f"Tebrikler! {self.attempts} denemede buldun!")
                if not self.high_score or self.attempts < self.high_score:
                    self.high_score = self.attempts
                    self.save_high_score()
                    self.high_score_label.config(text=f"En İyi Skor: {self.high_score}")
                messagebox.showinfo("Kazandın!", "Yeni oyun için 'Yeni Oyun' butonuna bas.")
        except ValueError:
            self.result_label.config(text="Lütfen bir sayı gir!")

    def new_game(self):
        self.number = random.randint(1, 100)
        self.attempts = 0
        self.history = []
        self.history_text.delete(1.0, tk.END)
        self.result_label.config(text="")
        self.guess_entry.delete(0, tk.END)

root = tk.Tk()
game = NumberGame(root)
root.mainloop()