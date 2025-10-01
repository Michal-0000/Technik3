lista = [2,3,6,3,6,6,1,9]

for el in lista:
    print(el)
    
print("-"*20)

for i in range(len(lista)):
    print(f"{i} : {lista[i]}")
    
print("-"*20)

for i, v in enumerate(lista):
    print(f"{i} : {v}")