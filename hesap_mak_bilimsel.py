
import tkinter as tk
from tkinter import messagebox
import math
from pyparsing import nums, Word, Literal, Forward, oneOf, Optional

class Calculator:
    def __init__(self, root):
        self.root = root
        self.root.title("Bilimsel Hesap Makinesi")
        self.root.geometry("300x400")
        self.history = []

        
        self.entry = tk.Entry(root, width=20, font=("Arial", 12), justify="right")
        self.entry.grid(row=0, column=0, columnspan=4, padx=5, pady=5)

        self.history_text = tk.Text(root, height=5, width=30, state="disabled")
        self.history_text.grid(row=1, column=0, columnspan=4, padx=5, pady=5)

        
        buttons = [
            ("7", 2, 0), ("8", 2, 1), ("9", 2, 2), ("/", 2, 3),
            ("4", 3, 0), ("5", 3, 1), ("6", 3, 2), ("*", 3, 3),
            ("1", 4, 0), ("2", 4, 1), ("3", 4, 2), ("-", 4, 3),
            ("0", 5, 0), (".", 5, 1), ("=", 5, 2), ("+", 5, 3),
            ("√", 6, 0), ("^", 6, 1), ("sin", 6, 2), ("cos", 6, 3),
            ("C", 7, 0)
        ]

        for (text, row, col) in buttons:
            tk.Button(root, text=text, width=5, 
                     command=lambda t=text: self.button_click(t)).grid(row=row, column=col, padx=2, pady=2)

    def evaluate_expression(self, expr):
        """Matematiksel ifadeyi güvenli bir şekilde değerlendirir."""
        try:
            
            number = Word(nums + ".")
            operator = oneOf("+ - * / ^")
            lpar = Literal("(").suppress()
            rpar = Literal(")").suppress()
            sin = Literal("sin")
            cos = Literal("cos")
            sqrt = Literal("√")
            expr_ = Forward()
            atom = number | (lpar + expr_ + rpar)
            expr_ << (atom | (sin + lpar + expr_ + rpar) | (cos + lpar + expr_ + rpar) | 
                     (sqrt + lpar + expr_ + rpar)) + Optional(operator + expr_)
            
            def parse_action(tokens):
                result = None
                if len(tokens) == 1:
                    result = float(tokens[0])
                elif tokens[0] == "sin":
                    result = math.sin(math.radians(float(tokens[2])))
                elif tokens[0] == "cos":
                    result = math.cos(math.radians(float(tokens[2])))
                elif tokens[0] == "√":
                    result = math.sqrt(float(tokens[2]))
                else:
                    left = float(tokens[0]) if isinstance(tokens[0], str) else tokens[0]
                    for i in range(1, len(tokens), 2):
                        op = tokens[i]
                        right = float(tokens[i + 1]) if isinstance(tokens[i + 1], str) else tokens[i + 1]
                        if op == "+":
                            left += right
                        elif op == "-":
                            left -= right
                        elif op == "*":
                            left *= right
                        elif op == "/":
                            if right == 0:
                                raise ValueError("Sıfıra bölme hatası!")
                            left /= right
                        elif op == "^":
                            left **= right
                    result = left
                return result

            expr_.setParseAction(parse_action)
            result = expr_.parseString(expr, parseAll=True)[0]
            return result
        except Exception as e:
            return f"Hata: {str(e)}"

    def button_click(self, value):
        current = self.entry.get()
        if value == "=":
            try:
               
                expr = current.replace("sin", "sin ").replace("cos", "cos ").replace("√", "√ ")
                result = self.evaluate_expression(expr)
                self.entry.delete(0, tk.END)
                self.entry.insert(tk.END, str(result))
                
               
                self.history.append(f"{current} = {result}")
                self.history_text.configure(state="normal")
                self.history_text.delete(1.0, tk.END)
                self.history_text.insert(tk.END, "\n".join(self.history[-5:]))
                self.history_text.configure(state="disabled")
            except Exception as e:
                messagebox.showerror("Hata", f"Geçersiz ifade: {e}")
                self.entry.delete(0, tk.END)
        elif value == "C":
            self.entry.delete(0, tk.END)
        else:
            self.entry.insert(tk.END, value)

root = tk.Tk()
calc = Calculator(root)
root.mainloop()
