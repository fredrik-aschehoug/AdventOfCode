module Tests

open System.IO
open Xunit

[<Theory>]
[<InlineData("Input/input-day1-test.txt", 24000, 45000)>]
[<InlineData("Input/input-day1.txt", 68775, 202585)>]
let ``Day01`` (fileName, part1Result, part2Result) =
    let text = File.ReadAllText(fileName)

    let topElf = Day01.part1 text
    let top3Sum = Day01.part2 text

    Assert.Equal(part1Result, topElf)
    Assert.Equal(part2Result, top3Sum)

[<Theory>]
[<InlineData("Input/input-day2-test.txt", 15, 12)>]
[<InlineData("Input/input-day2.txt", 11386, 13600)>]
let ``Day02`` (fileName, part1Result, part2Result) =
    let lines = File.ReadAllLines(fileName)

    let score = Day02.part1 lines
    let correctScore = Day02.part2 lines

    Assert.Equal(part1Result, score)
    Assert.Equal(part2Result, correctScore)

[<Theory>]
[<InlineData("Input/input-day3-test.txt", 157, 70)>]
[<InlineData("Input/input-day3.txt", 7872, 2497)>]
let ``Day03`` (fileName, part1Result, part2Result) =
    let lines = File.ReadAllLines(fileName)
    
    let prioritySum = Day03.part1 lines
    let badgeSum = Day03.part2 lines
    
    Assert.Equal(part1Result, prioritySum)
    Assert.Equal(part2Result, badgeSum)

[<Theory>]
[<InlineData("Input/input-day4-test.txt", 2, 4)>]
[<InlineData("Input/input-day4.txt", 431, 823)>]
let ``Day04`` (fileName, part1Result, part2Result) =
    let lines = File.ReadAllLines(fileName)
        
    let strictOverlappingPairs = Day04.part1 lines
    let overlappingPairs = Day04.part2 lines
        
    Assert.Equal(part1Result, strictOverlappingPairs)
    Assert.Equal(part2Result, overlappingPairs)

[<Theory>]
[<InlineData("Input/input-day5-test.txt", "CMZ", "MCD")>]
[<InlineData("Input/input-day5.txt", "TLNGFGMFN", "FGLQJCMBD")>]
let ``Day05`` (fileName, part1Result, part2Result) =
    let text = File.ReadAllText(fileName)
        
    let crates = Day05.part1 text
    let crates9001 = Day05.part2 text
        
    Assert.Equal(part1Result, crates)
    Assert.Equal(part2Result, crates9001)

[<Theory>]
[<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7, 19)>]
[<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5, 23)>]
[<InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6, 23)>]
[<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10, 29)>]
[<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11, 26)>]
[<InlineData(
    "vldvlvvhwhttcsttpntnvvqpqpddmlddwhwcwnwmwfwppdrrhllcwwgwhwvhwhshchshtsstzstztgtlggcwwtptrppfpggwpwmppnfpfnfznffmvfmvffgfwwwgrrqgglrgrqqlslhhgjgwwdswsbwwqswqwnqwqpqttqstqtjqqctcbtcbttcptpbbsmmhggwmggjllcpcvcrrphpjjwzwgzgtzggscggwdgghlhnhddlclrcchllrlbbnlbbgpbgghvggpbgpgssbszzjbbcpbpttwztwwgngnqqgllcvlvlzvzwwzssbppjwwvswwbjwbjwwwsjsdjsszmssfvsvcscqssnbnzbzzhsszttfvvdllzjzsjjzzvzsvzzdvvcpphfhzhrzrnnwffnrrhwrhrnrhnrrgfgmmzwmzmhzzsrzrgggnfntnpnqqdhhmrmrrqdqwqsqmssmllmvmgglttdmdffwzzhszhzphzphplpvpzvvsvcvgvqgqpgqqrmqmqssdbdcdpphddvppfggwrgrdgrggtvggrttmpmvmnmwnmmlcccwssfjftfbbgqbbnlldzlddzbbvmmvbmvvbsszggmnggqsqvssdlddqbbtfbttlhhlssplphlhzzcmmdcmmlqlqmmtddztzctzzlglwlzwwsmsddbrrzqqpdpjdpjjzhjjjzttvvwcvcdvvwqvvwqqgpgjgwgvgmmdjjmbbttmffwgwgppspzzvddjnjppmsscjczcqcczlzjzbbzmzllsshrrdtdttjdtdnnwbwttzptztrzzgfgfqfjjlwjjbfbsbmmhphqqjlqjjjshsvvrzrffvnfftrrpzzrdrbbcqbqjqccphhwfwgfwgwgwzzhggddctcsttjgjppghppfhhlnhhhwfwrfrggtjjgjbgbjbrrssjvvlcvvdzvdzzjhhgpprnpnpggfmfgfzfrzzsjjwhhrmmmvppgfffdsfddwlddmccjfcjjrwwsmwsstlsszbbjssjtsjjmpjpqqzffhphfffrzffnbnvnzvnvsvjjbljlflglrlvvghhcrhccnhccdbcdclcbbgffhwhnwwrwbbngnwwlpwlwsllsffzvzbzhbhppvdvfdvffvsvlslcslsqqszqzrrqbrrpjjvgjggbvvpbblnlvnnvrrprbpbvbccrjsdfrnqvhgfrwtvqjfzflnqqgbwlvfwwmrgnsltsqjfcctdwhqrstpvllhfrbnvnhvvgfvhbsgppslqnhmwdnrjnpfmrppppqpmrmcvtndrgwngrblpvrgnbhgtflthdjdtqhwcfzbdwsjshhnglprfcjfdwffmhbvhshbzsgdsbdwpcjfhrccqmjslqjjrwnbtqftqlvgnpmmzlfnmjzvrfslmmvhqwzjqbwsqfcnlmgdwlcbrlqlfwzhcfjsnncnnjqltfccmllhnjczqssjnjmhqbhqzdplbvfdpmdjmgthvqgjzqqschzgtmpdzmvvhlrwjpbqfplcqdbjfjfcrzdclctldvvqphtnvmgzvwprhzmbsbgfjlhvbtcmnccrgrpjlcjqqfcgjhtwvfstrtzszgcprmcngbhbdvjbfvgqdlhzgtzcjqnjmdtmwzchcfhzhgwprgrzbfwbhstfbprhnbzhsglmwhcjbppnshmzlnzsmbhcrmvpdgftfrwjfnmdvtrrqwjmzlbdjppsnvmlstsnrjwslqtqfmfcspzgrqhshhvclvqdfpbmzvsnthmcrzdmzqcjnnmbwbdlbfmcrzjjsrjbwchlvljplqdbjfchbslcvbjvvzfgdzmmnrgqwftppgpfwhfvdqqsrphrqmdtzjghlldfpgnczzjhqhfjvgqmcpzqssfqsfblcvqfttznpmvczprcptgcfwwlwsmqvfrjzcwbhppsjghmltqtcqljmpjzddncbslqdvgzhdvfpdpgpzljrfnjwdtnbdjwzjvmhqvnrdrjmhcfsbjcwtflljwjvtjbsbhzbghnzwtwpwzzwnfhwszsghggqthcbtwjrhdphbdslzmwhpmtjfbnpzspfqrvvtsjpvjmbtwrsqvfzzphllbvmvczsphdtblgdczjsqqthgscdqpvnmbpblspbcmpgjjtjtdrwhrqcgbrvlcsrwzwnjlgbfjbfgwpqpvnnmmgbdrhrwsptmddvtgbjhgzcphzmscjrqlnngpsnmjhvtmnhmqmcwdpjpbjsntcgppqrjndfsfhrhcvgcmrfrrsvnddwjsndlwffrgqnldqnvtgfvdrwtrlcqhltmbvdndzpdqndqrbtzqwbmbtzzsqftjftcnbrtsgvdrmnqlbbmhwmzpngltcslwdnpzpvstpdtfdcqvlwtbppsjvpdbspzlwnfvgcslzvmrpgplbnrvwpfwnrhcncdzptrjsqvghrczmrfwfntqlvlccwtbwqdcngzlqqvvnvfttqmcbqfqndhlsmbvcnstjcbpffmsptdnqbntnhhdctgdbnvwzgwznsgpvmslpmlcffsdtfnlcmbdgbntcslrlhfmrpddmjjttbtcrgbmfsbbwphtmlrdrgffdlnrwndhttjrplstwfwlpnljlcjphdvdvslwvnstqlrsgwdltlqwzdgsltzjqsgwqpbzgvqbdmvqtdgsnhttqprttzrnmddzdnqsgmnhfrmmfnrmltgjqpmgmdzdwpnzdsgstmwlgstmtjtqlhngmpwdqscrjmpmndddppsgthtbmznndswpsftcfltmhbbglnlmlszsssrlgbzcqpngvtgttlblsthmrltgctpgpjmhqqbldfgcrmclsmjhnjspzgwpmwncjgwrgdjmfgrpndztfdssmjhfmstgbjjzvmrpbmfzljpffwgvszwvtclfdnnbswzpjgthcbzpcbmgfvhfwnfthjdmnzdptqflzldnvnmfqnbggsrzjjssdntqhsjltjlfvjhncbrfbhllmqdpdnlbjptdcrqqghvvfvzzvtbvnjhshptcmgcnlmmpgdggdsfnpfsgrbcnfvrvfcqdfdfbgfvqcspvnrrljsgdtsbbcvcqnlwmrfgjhbdnjqgpggnpqtqgwspgljbrsggnmbmdbctwsdzqjmzrcwqgsvnhlpnlnqgfvgdfpgwsbqpqjcjpwwbrtzqhhgswggwnhmzwtvrqcrgbsrjspmczctgprgcwjtnzghvzqgnpmfqdswnzfzdbpdnpcgmwdrpmjtzhhwcnrrpfvqsgbrzngmwdgvjnmcftcjpcmdvcwjgfgvjrblsdnbsgfmjnvvvfwpfhztbgfddlcljzmwrwglnrfbnphlpvvcbfnwpsmsnhshzwrpnljzstmglrwdcctqlbwvqtfpjjdqzgncwgsnhczhvnvnzzmsjhfvgpdrhsmgnrfjcrzblzncdlffjrcqrqqdnjhgwgdgjlgbtphzgrjvmgnqrvdgmtgvpdbzqcvsfctrntjsnfcwnzpslzsvmtjhtcvcdsbqflbmtvclssrvcwjwcbspjgqhznzpttlbsnrpdrnqsddlcvjdrnqcgjhjfdclhwscdpbsjzcmrhgfwdnqbzqjsdqwbqdfcrztzfvclvbnhqstjztqdmsvlfqzmllphgrnwjqpdlrdnsbdltrggvlmdpfdwrdwnsdnscfcjzmrwqpsjwzrqcqcfndlvtfftbhdcbgcgtrfqrqnvwgbpstrtzgpjcjswfcwgvfnwlpprthntmlqbchjcwnqgppchgtvrzjbdzptfqqbmchmpqlnnfvpghjnmshpcjgsprbjpqnpwwddnswnfjvbzwszplhnhgzmzdqncmqrqtbqhdwbtrbrljpcwbdhjzvcqpdgvbtczlhwwzfmgvffnbcglpdqjdsnhhtnvvmtnhlbqcfqjfcgmcnqstzbgmqcfsgrzncwcfrlpsctpspvvdzwtbrhqzhfcwvwqvtzrmfjgpmlsdjmlgwhcldqlhsjvprvnmzcsldzfpzhmzdbqbpwnrsffswbjcwjgblnlcwzqlmcgfstqggdbsqpcpqcgfvn",
    1198,
    3120)>]
let ``Day06`` (buffer, part1Result, part2Result) =
    let packetStart = Day06.part1 buffer
    let messageStart= Day06.part2 buffer
        
    Assert.Equal(part1Result, packetStart)
    Assert.Equal(part2Result, messageStart)

[<Theory>]
[<InlineData("Input/input-day7-test.txt", 95437, 24933642)>]
[<InlineData("Input/input-day7.txt", 2061777, 4473403)>]
let ``Day07`` (fileName, part1Result, part2Result) =
    let lines = File.ReadAllLines(fileName)
        
    let sum = Day07.part1 lines
    let size = Day07.part2 lines
        
    Assert.Equal(part1Result, sum)
    Assert.Equal(part2Result, size)

[<Theory>]
[<InlineData("Input/input-day8-test.txt", 21, 8)>]
[<InlineData("Input/input-day8.txt", 1676, 313200)>]
let ``Day08`` (fileName, part1Result, part2Result) =
    let lines = File.ReadAllLines(fileName)
        
    let sum = Day08.part1 lines
    let topScenicScore = Day08.part2 lines
        
    Assert.Equal(part1Result, sum)
    Assert.Equal(part2Result, topScenicScore)

[<Theory>]
[<InlineData("Input/input-day9-test.txt", 13, 0)>]
[<InlineData("Input/input-day9.txt", 6212, 0)>]
let ``Day09`` (fileName, part1Result, part2Result) =
    let lines = File.ReadAllLines(fileName)
        
    let positionsVisited = Day09.part1 lines
    //let x = Day08.part2 lines
        
    Assert.Equal(part1Result, positionsVisited)
    //Assert.Equal(part2Result, x)

[<Theory>]
[<InlineData("Input/input-day10-test.txt", 13140)>]
[<InlineData("Input/input-day10.txt", 17380)>]
let ``Day10`` (fileName, part1Result) =
    let lines = File.ReadAllLines(fileName)
        
    let sum = Day10.part1 lines
        
    Assert.Equal(part1Result, sum)

[<Theory>]
[<InlineData("Input/input-day11-test.txt", 10605, 2713310158L)>]
[<InlineData("Input/input-day11.txt", 107822, 27267163742L)>]
let ``Day11`` (fileName, part1Result, part2Result: int64) =
    let text = File.ReadAllText(fileName)
        
    let monkeyBusiness = Day11.part1 text
    let monkeyBusinessV2 = Day11.part2 text
        
    Assert.Equal(part1Result, monkeyBusiness)
    Assert.Equal(part2Result, monkeyBusinessV2)

[<Theory>]
[<InlineData("Input/input-day13-test.txt", 13, 0)>]
[<InlineData("Input/input-day13.txt", 6478, 0)>]
let ``Day13`` (fileName, part1Result, part2Result) =
    let text = File.ReadAllText(fileName)
        
    let sum = Day13.part1 text
    //let monkeyBusinessV2 = Day13.part2 text
        
    Assert.Equal(part1Result, sum)
    //Assert.Equal(part2Result, monkeyBusinessV2)