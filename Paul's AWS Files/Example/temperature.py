from matplotlib import pyplot, dates
from csv import reader
from dateutil import parser

with open('Columbus_Ed_astro_pi_datalog.csv', 'r') as f:
    data = list(reader(f))

temp = [i[3] for i in data[1::]]
time = [parser.parse(i[19]) for i in data[1::]]

pyplot.plot(time, temp)
pyplot.title('Temperature changes over Time')
pyplot.xlabel('Time/hours')
pyplot.ylabel('Temperature/$^\circ$C')
#pyplot.show()
pyplot.savefig('Columbus_Ed.png')
