import random as rd

A = [rd.randint(1,10) for i in range(20)]

for i,v in enumerate(A):
    print(f"{i} : {v}")
    
B = [i for i in range(20)]

for i,v in enumerate(B):
    print(f"{i} : {v}")
    
C = ["Jabłko", "Malina", "Banan", "Truskawka"]
dlugie = [owoc for owoc in C if len(owoc) > 5]
print(dlugie)