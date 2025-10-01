
with open("liczby.txt", "+rt") as file:
    linie = file.readlines()
    linie = [linia.rstrip("\n") for linia in linie]
    
    for linia in linie:
        if int(linia) % 2 == 1:
            print(linia)