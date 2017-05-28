# ShootingStarsGameVPProject
Изработиле:

Ана Перинска		131107

Мартин  Поповски	131132

Владимир Димовски	141102


1.	Опис на играта

Shooting Stars е игра каде главната цел е да се погодат сите ѕвезди кои паѓаат. На почетокот се појавува welcome screen каде има можност да се одбере дали ќе се стартува играта или ќе се исклучи. Со клик на копчето „Почни ја играта!“ играта почнува. Кога ќе се вклучи новиот екран гледаме позадина за која е искористена слика и ѕвезди во две бои кои паѓаат на целиот екран. Играта почнува со 10 животи така што играчот има можност да остави 10 ѕвезди да паднат пред да ја изгуби играта. Со клик на белите ѕвезди тие стануваат жолти и потоа со уште еден клик целосно ги снемува. Резултатот цело време се зголемува за 1 иако белите ѕвезди треба да бидат кликнати два пати. Со секоја пропуштена ѕвезда бројот на животи се намалува. Кога ќе се стигне до резултат 30 ѕвездите почнуваат да паѓаат побрзо, потоа кога ќе се стигне до резултат 60 се влегува во финалниот левел каде ѕвездите паѓаат уште побрзо и речиси е невозможно да се издржи повеќе од една минута. Времето е неограничено и завршува кога ќе се изгубат сите 10 животи. Тогаш се појавува game over screen каде што е прикажан вкупниот резултат и има можност за излез од играта или повторно играње.

2.	Имплементација, класи, алгоритми

Почетниот екран се состои од слика која е поставена како позадина и две копчиња, едното за почеток на играта и другото за излез. Сликата е имплементирана со Bitmap што претставува имплементација на Image класата која е апстрактна класа. Bitmap ги чува пиксел податоците за графиката на сликата и нејзините атрибути. Сликата се исцртува со DrawImage() методот. Исто така користиме и функција за динамичко наоѓање на патеката на сликата бидејќи за секој компјутер постои различна патека до истата.
Со клик на копчето „Почни ја играта!“ се прави инстанца од Form1 односно формата каде што се наоѓа играта. Со клика на копчето „Излез!“ се повикува Application.Exit() што предизвикува исклучување на играта.



- Почетен екран

 ![Alt text](screenshots/poceten.png)
 
Имаме две класи, Star и StarsDoc каде што ни се имплементирани методите за цртање на ѕвездите, методот за уништување на ѕвездите при клик и методот за движење. На почетокот се дефинира правоаголник, којшто го создаваме со една центарот и радиусот на кружницата од таа точка земен како должина и ширина на правоаголникот (бидејќи се исти всушност квадрат имаме). Потоа се повикува функцијата StarPoints којашто го зема правоаголникот и бројот на краци што ќе го има ѕвездата. Колку краци е пренесено да има ѕвездата, толку меморија се алоцира во низа од типот на  PointF[](поинт со децимални вредности). cx и cy се координатите на центарот на правоаголникот, а rx и ry се радиусот на кружницата(всушност rx=ry). Потоа во фор циклусот за секоја инстанца се зголемува аголот тета за толку колку што имаме краци во ѕвездата(поради начинот на имплементација работи само за ѕвезди со непарен број на краци). За секој крак се наоѓаат координатите на неговиот крај според аголот тета од центарот кон кружницата. Аолот дтета е поместувањето на аголот тета и во нашиот случај тој е еднаков на 4*п/5. На крајот имаме 5 координати на краци кои ги враќа функцијата и потоа во просторот кој што го зафаќаат тие се вметнува соодветната боја.
Движењето е имплементирано со движење на центарот на ѕвездата вертикално надолу по Y-оската. Имаме и променлива state со која проверуваме која боја е ѕвездата за да знаеме во кој момент да ја отстраниме соодветната ѕвезда од екранот. Како што веќе напоменав, со клик на белите ѕвезди тие стануваат жолти и потоа со уште еден клик целосно ги снемува. Користиме бројач missedStars кој се намалува секогаш кога ќе отстраниме ѕвезда од екранот и кој ни означува колку ѕвезди сме пропуштиле, односно уште колку животи ни останале. Кога резултатот ќе стане 0, тогаш ни се отвара новиот прозорец Game over кој означува крај на играта.

- Игра

 ![Alt text](screenshots/igra.png)
 
На крајниот прозорец е имплементирана слика на ист начин како горенаведениот и над неа се две копчиња со едноставни функционалности како и две лабели на кои се прикажува конечниот резултат.
Копчето „Обиди се повторно!“ ја стартува играта отпочеток со повикување на Application.Restart(), а копчето „Излез!“ се повикува Application.Exit() што предизвикува исклучување на играта.


- Екран за крај на играта
 
 ![Alt text](screenshots/game_over.png)
 
3.	Серијализација

За некои податоци да бидат достапни и после терминација на програмата, искористивме серијализација. За еден објект да можеме да го серијализираме, потребно е класата од која е инстанциран да биде серијабилна. За читање на веќе внесени податоци во овие фајлови се повикува методот Deserialize(); со FileStream од содржината на сериајлизираниот фајл како аргумент. Излезот од овој метод се кастира како соодветен објект и се доделува на веќе инстанциран null објект од иста класа.

