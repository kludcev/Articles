using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Articles
{
    public class AutomapperFactory
    {
        public static Mapper GetMapper(params Assembly[] assemblies)
        {
            var activatedProfiles = new List<Profile>();
            foreach (var assembly in assemblies.Distinct())
            {
                IEnumerable<Type> profileTypes =
                    assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Profile)) && !type.IsAbstract);
                foreach (var profileType in profileTypes)
                {
                    activatedProfiles.Add((Profile)Activator.CreateInstance(profileType));
                }
            }
            var config = new MapperConfiguration(configure => configure.AddProfiles(activatedProfiles));
            return new Mapper(config);
        }
    }
}