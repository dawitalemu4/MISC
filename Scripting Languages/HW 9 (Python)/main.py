import json
from son import son_age
from father import father_age
from grandfather import grandfather_age

son_data = {"name": "Son", "age": son_age}
father_data = {"name": "Father", "age": father_age}
grandfather_data = {"name": "Grandfather", "age": grandfather_age}

print("Son's JSON data:")
print(json.dumps(son_data, indent=4))

print("\nFather's JSON data:")
print(json.dumps(father_data, indent=4))

print("\nGrandfather's JSON data:")
print(json.dumps(grandfather_data, indent=4))