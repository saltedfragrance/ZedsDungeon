﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.Art
{
    internal class AsciiArt
    {
        internal string MainMenuArt { get; } = @"
                              ______        _ _       _____                                     
                             |___  /       | ( )     |  __ \                                    
                                / / ___  __| |/ ___  | |  | |_   _ _ __   __ _  ___  ___  _ __  
                               / / / _ \/ _` | / __| | |  | | | | | '_ \ / _` |/ _ \/ _ \| '_ \ 
                              / /_|  __/ (_| | \__ \ | |__| | |_| | | | | (_| |  __/ (_) | | | |
                             /_____\___|\__,_| |___/ |_____/ \__,_|_| |_|\__, |\___|\___/|_| |_|
                                                                          __/ |                 
                                                                         |___/                  ";
        internal string CharacterCreation { get; } = @"
                   _____ _                          _               _____                _   _             
                  / ____| |                        | |             / ____|              | | (_)            
                 | |    | |__   __ _ _ __ __ _  ___| |_ ___ _ __  | |     _ __ ___  __ _| |_ _  ___  _ __  
                 | |    | '_ \ / _` | '__/ _` |/ __| __/ _ \ '__| | |    | '__/ _ \/ _` | __| |/ _ \| '_ \ 
                 | |____| | | | (_| | | | (_| | (__| ||  __/ |    | |____| | |  __/ (_| | |_| | (_) | | | |
                  \_____|_| |_|\__,_|_|  \__,_|\___|\__\___|_|     \_____|_|  \___|\__,_|\__|_|\___/|_| |_|
                                                                                           
                                                                                                          ";

        internal string Battle { get; } = @"
                                  ____        _   _   _         _____                          
                                 |  _ \      | | | | | |       / ____|                         
                                 | |_) | __ _| |_| |_| | ___  | (___   ___ _ __ ___  ___ _ __  
                                 |  _ < / _` | __| __| |/ _ \  \___ \ / __| '__/ _ \/ _ \ '_ \ 
                                 | |_) | (_| | |_| |_| |  __/  ____) | (__| | |  __/  __/ | | |
                                 |____/ \__,_|\__|\__|_|\___| |_____/ \___|_|  \___|\___|_| |_|
                                                               
                                                                   ";

        internal string Inventory { get; } = @"
                                      _____                      _                   
                                     |_   _|                    | |                  
                                       | |  _ ____   _____ _ __ | |_ ___  _ __ _   _ 
                                       | | | '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | |
                                      _| |_| | | \ V /  __/ | | | || (_) | |  | |_| |
                                     |_____|_| |_|\_/ \___|_| |_|\__\___/|_|   \__, |
                                                                                __/ |
                                                                               |___/ ";

        internal string YouDied { get; } = @"
                                       _____                         ____                 
                                      / ____|                       / __ \                
                                     | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
                                     | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
                                     | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
                                      \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   
                                                      
                                                                                          ";

        internal string Victory { get; } = @"
                                         __      ___      _                   
                                         \ \    / (_)    | |                  
                                          \ \  / / _  ___| |_ ___  _ __ _   _ 
                                           \ \/ / | |/ __| __/ _ \| '__| | | |
                                            \  /  | | (__| || (_) | |  | |_| |
                                             \/   |_|\___|\__\___/|_|   \__, |
                                                                         __/ |
                                                                        |___/ ";

        internal string Fight { get; } = @"
                                  ______ _       _     _                  ______ _          ___  
                                 |  ____(_)     | |   | |                |  ____| |        |__ \ 
                                 | |__   _  __ _| |__ | |_    ___  _ __  | |__  | | ___  ___  ) |
                                 |  __| | |/ _` | '_ \| __|  / _ \| '__| |  __| | |/ _ \/ _ \/ / 
                                 | |    | | (_| | | | | |_  | (_) | |    | |    | |  __/  __/_|  
                                 |_|    |_|\__, |_| |_|\__|  \___/|_|    |_|    |_|\___|\___(_)  
                                            __/ |                                                
                                           |___/                                                 ";

        internal string Credits { get; } = @"
                                               _____              _ _ _       
                                              / ____|            | (_) |      
                                             | |     _ __ ___  __| |_| |_ ___ 
                                             | |    | '__/ _ \/ _` | | __/ __|
                                             | |____| | |  __/ (_| | | |_\__ \
                                              \_____|_|  \___|\__,_|_|\__|___/
                                                                  
                                            ";

        internal string Resurrected { get; } = @"
                                  _____                                    _           _ 
                                 |  __ \                                  | |         | |
                                 | |__) |___  ___ _   _ _ __ _ __ ___  ___| |_ ___  __| |
                                 |  _  // _ \/ __| | | | '__| '__/ _ \/ __| __/ _ \/ _` |
                                 | | \ \  __/\__ \ |_| | |  | | |  __/ (__| ||  __/ (_| |
                                 |_|  \_\___||___/\__,_|_|  |_|  \___|\___|\__\___|\__,_|
                                                         
                                                                                         ";
    }
}