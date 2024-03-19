import random
from random import randint
f = open("input2.txt", "w")
d = [randint(-1000000, 1000000) for _ in range(1000000)]
for p in d:
    f.write(str(p) + '\n')
f.close()