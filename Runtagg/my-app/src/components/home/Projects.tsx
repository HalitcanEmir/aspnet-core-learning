"use client";

import { motion } from "framer-motion";
import SectionWrapper from "./SectionWrapper";

const projects = [
  {
    category: "Game",
    name: "Nebula Drift",
    description:
      "A small-scope, high-polish arcade prototype built for a weekend jam and iterated into a playable vertical slice.",
    stack: "Unity · URP · FMOD",
  },
  {
    category: "Web",
    name: "Crewboard",
    description:
      "Internal crew dashboard to track sprints, roles and experiment backlogs across multiple projects.",
    stack: "Next.js · PostgreSQL · Tailwind",
  },
  {
    category: "AI / Competition",
    name: "Teknofest Control Hub",
    description:
      "Control, telemetry and replay tools for a competition team, built under strict deadlines and constraints.",
    stack: "Python · FastAPI · React",
  },
  {
    category: "Hybrid",
    name: "Playtest Lab",
    description:
      "A cross-project toolkit for remote playtesting, survey collection and fast iteration on game balance.",
    stack: "Next.js · Supabase · Analytics",
  },
];

export default function Projects() {
  return (
    <SectionWrapper id="projects" className="relative space-y-10">
      <div className="pointer-events-none absolute -inset-x-20 top-10 -z-10 h-64 rounded-[40px] bg-[radial-gradient(circle_at_0%_0%,rgba(124,58,237,0.35),transparent_60%),radial-gradient(circle_at_100%_100%,rgba(56,189,248,0.35),transparent_60%)] opacity-70 blur-3xl" />

      <div className="space-y-3">
        <p className="text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-400">
          Projects
        </p>
        <h2 className="text-2xl font-semibold uppercase tracking-[0.18em] text-slate-100 sm:text-3xl">
          Some things we’ve shipped
        </h2>
        <p className="max-w-2xl text-sm text-slate-300">
          From student hacks to production-level releases, these are some of our
          playgrounds.
        </p>
      </div>

      <div className="grid gap-6 md:grid-cols-2">
        {projects.map((project, index) => (
          <motion.article
            key={project.name}
            initial={{ opacity: 0, y: 22 }}
            whileInView={{ opacity: 1, y: 0 }}
            viewport={{ once: true, margin: "0px 0px -20% 0px" }}
            transition={{ duration: 0.55, delay: index * 0.06 }}
            className="relative flex flex-col justify-between gap-4 overflow-hidden rounded-3xl border border-white/15 bg-gradient-to-br from-white/10 via-white/5 to-white/0 p-[1px] shadow-[0_22px_80px_rgba(15,23,42,0.95)]"
          >
            <div className="relative h-full rounded-[22px] bg-gradient-to-br from-slate-950/80 via-slate-900/80 to-slate-950/90 p-5">
              <div className="pointer-events-none absolute inset-0 bg-[radial-gradient(circle_at_0%_0%,rgba(124,58,237,0.35),transparent_55%),radial-gradient(circle_at_100%_100%,rgba(56,189,248,0.35),transparent_55%)] opacity-60 mix-blend-screen" />
              <div className="relative flex h-full flex-col gap-4">
                <div className="flex items-center justify-between gap-2">
                  <span className="inline-flex rounded-full bg-slate-900/70 px-3 py-1 text-[10px] uppercase tracking-[0.25em] text-slate-200">
                    {project.category}
                  </span>
                  <a
                    href="#"
                    className="text-[10px] uppercase tracking-[0.24em] text-sky-200/80 hover:text-sky-100"
                  >
                    View case →
                  </a>
                </div>
                <div className="space-y-2">
                  <h3 className="text-base font-semibold uppercase tracking-[0.22em] text-slate-100">
                    {project.name}
                  </h3>
                  <p className="text-xs leading-relaxed text-slate-200/90">
                    {project.description}
                  </p>
                </div>
                <div className="mt-auto flex items-center justify-between gap-2 pt-3 text-[11px] text-slate-300/90">
                  <span>{project.stack}</span>
                  <span className="text-[10px] text-slate-400">
                    Playgrounds · Studio
                  </span>
                </div>
              </div>
            </div>
          </motion.article>
        ))}
      </div>
    </SectionWrapper>
  );
}

