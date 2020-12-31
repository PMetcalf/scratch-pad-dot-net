'''
Python OOP

Scratch pad for OOP concepts in Python.
'''

class Parrot:
    
    # Class attribute
    species = 'bird'

    # Instance attribute
    def __init__(self, name, age):
        self.name = name
        self.age = age

    # Instance methods
    def sing(self, song):
        return "{} sings {}".format(self.name, song)

    def dance(self):
        return "{} is now dancing".format(self.name)

# Instantiate the parrot class
blue = Parrot("Blue", 10)
Woo = Parrot("Woo", 15)

# Access class attributes
print("Blue is a {}".format(blue.__class__.species))
print("Woo is also a {}".format(Woo.__class__.species))

# Access the instance attributes
print("{} is {} years old".format( blue.name, blue.age))
print("{} is {} years old".format( Woo.name, Woo.age))

# Call instance methods
print(blue.sing("'Happy'"))
print(blue.dance())