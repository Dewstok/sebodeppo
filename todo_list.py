import sqlite3
import tkinter as tk
from tkinter import messagebox, ttk

def init_db():
    conn = sqlite3.connect("tasks.db")
    cursor = conn.cursor()
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS tasks (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            task TEXT NOT NULL,
            priority TEXT,
            completed BOOLEAN
        )
    ''')
    conn.commit()
    conn.close()

def add_task():
    task = task_entry.get()
    priority = priority_var.get()
    if task:
        conn = sqlite3.connect("tasks.db")
        cursor = conn.cursor()
        cursor.execute("INSERT INTO tasks (task, priority, completed) VALUES (?, ?, ?)", 
                      (task, priority, False))
        conn.commit()
        conn.close()
        task_entry.delete(0, tk.END)
        refresh_tasks()
    else:
        messagebox.showwarning("Uyarı", "Görev boş olamaz!")

def delete_task(task_id):
    conn = sqlite3.connect("tasks.db")
    cursor = conn.cursor()
    cursor.execute("DELETE FROM tasks WHERE id = ?", (task_id,))
    conn.commit()
    conn.close()
    refresh_tasks()

def toggle_complete(task_id, completed):
    conn = sqlite3.connect("tasks.db")
    cursor = conn.cursor()
    cursor.execute("UPDATE tasks SET completed = ? WHERE id = ?", (not completed, task_id))
    conn.commit()
    conn.close()
    refresh_tasks()

def refresh_tasks():
    for widget in task_frame.winfo_children():
        widget.destroy()
    conn = sqlite3.connect("tasks.db")
    cursor = conn.cursor()
    cursor.execute("SELECT id, task, priority, completed FROM tasks")
    for row in cursor.fetchall():
        task_id, task, priority, completed = row
        task_text = f"[{'✓' if completed else ' '}] {task} ({priority})"
        task_label = tk.Label(task_frame, text=task_text, font=("Arial", 10))
        task_label.pack(anchor="w")
        btn_frame = tk.Frame(task_frame)
        btn_frame.pack(anchor="w")
        tk.Button(btn_frame, text="Tamamla/Değiştir", 
                 command=lambda tid=task_id, c=completed: toggle_complete(tid, c)).pack(side=tk.LEFT)
        tk.Button(btn_frame, text="Sil", 
                 command=lambda tid=task_id: delete_task(tid)).pack(side=tk.LEFT)
    conn.close()

root = tk.Tk()
root.title("To-Do List Uygulaması")
root.geometry("400x500")

init_db()

tk.Label(root, text="Yeni Görev:", font=("Arial", 12)).pack(pady=5)
task_entry = tk.Entry(root, width=40)
task_entry.pack(pady=5)

priority_var = tk.StringVar(value="Orta")
tk.Label(root, text="Öncelik:", font=("Arial", 12)).pack()
priority_menu = ttk.Combobox(root, textvariable=priority_var, 
                            values=["Yüksek", "Orta", "Düşük"], state="readonly")
priority_menu.pack(pady=5)

tk.Button(root, text="Görev Ekle", command=add_task).pack(pady=10)

task_frame = tk.Frame(root)
task_frame.pack(pady=10, fill=tk.BOTH, expand=True)

refresh_tasks()
root.mainloop()